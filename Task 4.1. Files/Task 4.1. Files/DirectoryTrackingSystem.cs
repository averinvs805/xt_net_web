using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Task_4._1._Files
{
    /// <summary>
    /// Система для отслеживания изменений объекта
    /// </summary>
    class DirectoryTrackSystem
            : IDisposable
    {
        private readonly FileSystemWatcher FileSystemWatcher
            = new FileSystemWatcher();

        private readonly TextDifference TextDifference
            = new TextDifference();
        private readonly RelativePathFinder RelativePathFinder
            = new RelativePathFinder();

        private readonly LayerProvider LayerProvider;


        private readonly LayerApplier LayerApplier
            = new LayerApplier();
        private readonly StateStorage StateStorage
            = new StateStorage();



        public DirectoryTrackSystem(DirectoryInfo layersDir)
        {
            LayerProvider
                = new LayerProvider(layersDir);
        }



        public void StartListenDirectory(
            DirectoryInfo observDir,
            string filter = "*.txt"
            )
        {
            observDir.Refresh();

            if (!observDir.Exists)
            {
                throw new Exception("Наблюдаемая папка не найдено");
            }


            FileSystemWatcher.Path = observDir.FullName;
            FileSystemWatcher.Filter = filter;
            FileSystemWatcher.IncludeSubdirectories = true;

            FileSystemWatcher.Deleted += Watcher_Deleted;
            FileSystemWatcher.Created += Watcher_Created;
            FileSystemWatcher.Changed += Watcher_Changed;
            FileSystemWatcher.Renamed += Watcher_Renamed;

            //On
            FileSystemWatcher.EnableRaisingEvents = true;
        }

        public void GoToLayer(DateTime dateTime) { }


        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            //string fileEvent = "переименован в " + e.FullPath;
            //string filePath = e.OldFullPath;

            LayerInfo layer = new LayerInfo()
            {
                EventDate = DateTime.Now,
                ChangeType = WatcherChangeTypes.Renamed,
                FileName = e.OldName,
                NewName = e.Name,
                RelativePath = RelativePathFinder.GetRelativePath(e.FullPath, FileSystemWatcher.Path)
            };

            LayerApplier.Apply(StateStorage, layer);
            LayerProvider.SaveLayer(layer);
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            //string fileEvent = "изменен";
            //string filePath = e.FullPath;

            var oldState = StateStorage.FilesData[""];
            var newContent = File.ReadAllLines(e.FullPath);

            LayerInfo layer = new LayerInfo()
            {
                EventDate = DateTime.Now,
                ChangeType = WatcherChangeTypes.Changed,
                FileName = e.Name,
                AddOrUpdateData = TextDifference.Different(oldState.Text, newContent),
                RelativePath = RelativePathFinder.GetRelativePath(e.FullPath, FileSystemWatcher.Path)
            };

            LayerApplier.Apply(StateStorage, layer);
            LayerProvider.SaveLayer(layer);
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            //string fileEvent = "создан";
            //string filePath = e.FullPath;

            var data = File.ReadAllLines(e.FullPath);
            int rowNumber = 0;

            LayerInfo layer = new LayerInfo()
            {
                EventDate = DateTime.Now,
                ChangeType = WatcherChangeTypes.Changed,
                FileName = e.Name,
                RelativePath = RelativePathFinder.GetRelativePath(e.FullPath, FileSystemWatcher.Path),
                AddOrUpdateData = new AddOrUpdateData()
                {
                    ChangesRows = data
                        .Select(
                            elem => new RowInformation()
                            {
                                RowNumber = rowNumber++,
                                Context = elem
                            }
                        )
                        .ToList(),
                    LastRowNumber = data.Length
                }
            };

            LayerApplier.Apply(StateStorage, layer);
            LayerProvider.SaveLayer(layer);
        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            //string fileEvent = "удален";
            //string filePath = e.FullPath;

            LayerInfo layer = new LayerInfo()
            {
                EventDate = DateTime.Now,
                ChangeType = WatcherChangeTypes.Deleted,
                FileName = e.Name,
                RelativePath = RelativePathFinder.GetRelativePath(e.FullPath, FileSystemWatcher.Path)
            };

            LayerApplier.Apply(StateStorage, layer);
            LayerProvider.SaveLayer(layer);
        }


        #region

        private bool IsDisposed = false;

        protected void Dispose(bool disposing)
        {
            if (IsDisposed) return;
            if (disposing)
            {
                FileSystemWatcher.EnableRaisingEvents = false;
            }
            IsDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            // подавляем финализацию
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
