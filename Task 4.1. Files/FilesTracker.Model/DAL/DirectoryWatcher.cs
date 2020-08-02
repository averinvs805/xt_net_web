using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using FilesTracker.Model.Entities;
using FilesTracker.Model.Tools;


namespace FilesTracker.Model.DAL
{
    public class DirectoryWatcher
        : IDisposable
    {
        private readonly FileSystemWatcher FileSystemWatcher
            = new FileSystemWatcher();

        private readonly FileProvider FileProvider
            = new FileProvider();

        private readonly RelativePathFinder RelativePathFinder
            = new RelativePathFinder();


        public event Action<LayerInfo, WatcherChangeTypes> OnDirectoryEvent;

        public string Filter { set; get; } = "*.txt";


        public void StartListenDirectory(
            DirectoryInfo observDir
            )
        {
            observDir.Refresh();

            if (!observDir.Exists)
            {
                throw new Exception("Наблюдаемая папка не найдено");
            }

            FileSystemWatcher.Path = observDir.FullName;
            FileSystemWatcher.Filter = Filter;
            FileSystemWatcher.IncludeSubdirectories = true;

            //FileSystemWatcher.NotifyFilter = 
            //    NotifyFilters.LastAccess
            //    | NotifyFilters.LastWrite
            //    | NotifyFilters.CreationTime
            //    | NotifyFilters.DirectoryName
            //    | NotifyFilters.FileName;

            FileSystemWatcher.Deleted += Watcher_Deleted;
            FileSystemWatcher.Created += Watcher_Created;
            FileSystemWatcher.Changed += Watcher_Changed;
            FileSystemWatcher.Renamed += Watcher_Renamed;

            //On
            FileSystemWatcher.EnableRaisingEvents = true;
        }




        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            //string fileEvent = "переименован в " + e.FullPath;
            //string filePath = e.OldFullPath;

            LayerInfo layer = new LayerInfo()
            {
                EventDate = DateTime.Now,
                ChangeType = WatcherChangeTypes.Renamed,
                FileName = Path.GetFileName(e.OldName),
                NewName = Path.GetFileName(e.Name),
                RelativePath = RelativePathFinder.GetRelativePath(e.FullPath, FileSystemWatcher.Path)
            };

            OnDirectoryEvent?.Invoke(layer, e.ChangeType);
        }
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            //string fileEvent = "изменен";
            //string filePath = e.FullPath;

            LayerInfo layer = new LayerInfo()
            {
                EventDate = DateTime.Now,
                ChangeType = WatcherChangeTypes.Changed,
                FileName = Path.GetFileName(e.Name),
                RelativePath = RelativePathFinder.GetRelativePath(e.FullPath, FileSystemWatcher.Path)
            };

            OnDirectoryEvent?
                .Invoke(layer, e.ChangeType);

        }
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            //string fileEvent = "создан";
            //string filePath = e.FullPath;

            var data = FileProvider.TryReadAllLines(e.FullPath);
            int rowNumber = 0;

            LayerInfo layer = new LayerInfo()
            {
                EventDate = DateTime.Now,
                ChangeType = WatcherChangeTypes.Changed,
                FileName = Path.GetFileName(e.Name),
                RelativePath = RelativePathFinder.GetRelativePath(e.FullPath, FileSystemWatcher.Path),
                AddOrUpdateData = new AddOrUpdateData()
                {
                    ChangesRows = data
                        .Select(
                            elem => new RowInformation()
                            {
                                RowNumber = rowNumber++,
                                Content = elem
                            }
                        )
                        .ToList(),
                    LastRowNumber = data.Length
                }
            };

            OnDirectoryEvent?
                .Invoke(layer, e.ChangeType);
        }
        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            //string fileEvent = "удален";
            //string filePath = e.FullPath;

            LayerInfo layer = new LayerInfo()
            {
                EventDate = DateTime.Now,
                ChangeType = WatcherChangeTypes.Deleted,
                FileName = Path.GetFileName(e.Name),
                RelativePath = RelativePathFinder.GetRelativePath(e.FullPath, FileSystemWatcher.Path)
            };

            OnDirectoryEvent?
                .Invoke(layer, e.ChangeType);
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
