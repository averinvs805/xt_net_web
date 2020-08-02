using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using FilesTracker.Model.Entities;
using FilesTracker.Model.Tools;
using FilesTracker.Model.DAL;
using FilesTracker.Model.BLL;

namespace FilesTracker.Model
{
    /// <summary>
    /// Система для отслеживания изменений объекта
    /// </summary>
    public class DirectoryTrackingSystem
            : IDisposable
    {
        private readonly TextDifference TextDifferent
            = new TextDifference();

        private readonly RelativePathFinder RelativePathFinder
            = new RelativePathFinder();

        private readonly FileProvider FileProvider
            = new FileProvider();

        private readonly LayerApplier LayerApplier
            = new LayerApplier();


        private readonly DirectoryWatcher DirectoryWatcher
            = new DirectoryWatcher();
        private readonly LayerProvider LayerProvider = new LayerProvider();
        private StorageProvider StorageProvider = new StorageProvider();


        private StateStorage StateStorage
            = new StateStorage();

        private readonly Settings Settings;


        public Action<string> InActionLog { set; get; }


        public DirectoryTrackingSystem(Settings settings)
        {
            Settings = settings;
        }



        /// <summary>
        /// Начать наблюдение за папкой с фиксацией изменений
        /// </summary>

        public void StartListenDirectory()
        {
            Settings.ObservDir.Refresh();

            if (!Settings.ObservDir.Exists)
            {
                throw new Exception("Наблюдаемая папка не найдено");
            }

            InitIfNeed();

            DirectoryWatcher.OnDirectoryEvent += DirectoryWatcher_OnDirectoryEvent;
            DirectoryWatcher
                .StartListenDirectory(Settings.ObservDir);
        }


        /// <summary>
        /// Откат наблюдаемой папки к состоянию указанной даты
        /// </summary>
        /// <param name="dateTime"></param>
        public void GoToLayer(DateTime dateTime)
        {
            StateStorage = StorageProvider
                .ReadStorage(Settings.SrcFilesDir);

            var allLayers = LayerProvider
                .GetAllLayers(Settings.LayersDir);

            var applyLayers = allLayers
                .Where(e => e.EventDate <= dateTime)
                .ToArray();

            foreach (var elem in applyLayers)
            {
                StateStorage = LayerApplier.Apply(StateStorage, elem);
            }

            StorageProvider
                .WriteStorage(new DirectoryInfo(Settings.ObservedDirectoryPath), StateStorage);


            //Удаляем все слои, старше указанного
            var layersToRemove = allLayers
                .Where(e => e.EventDate > dateTime)
                .ToArray();

            foreach (var elem in layersToRemove)
            {
                LayerProvider.DeleteLayer(Settings.LayersDir, elem);
            }
        }



        /// <summary>
        /// Обработка события изменения (новый слой)
        /// </summary>
        private void DirectoryWatcher_OnDirectoryEvent(LayerInfo layer, WatcherChangeTypes type)
        {
            if (type == WatcherChangeTypes.Changed)
            {
                var oldState = StateStorage.FilesData[Path.Combine(layer.RelativePath, layer.FileName)];
                var oldRowsCount = oldState?.Text?.Length;

                var newContent = FileProvider.TryReadAllLines(
                    Path.Combine(Settings.ObservedDirectoryPath, layer.RelativePath, layer.FileName)
                    );

                layer.AddOrUpdateData = TextDifferent.Different(oldState.Text, newContent);

                //Если изменений не обнаружено
                if (
                    layer.AddOrUpdateData.ChangesRows.Count == 0
                    && layer.AddOrUpdateData.LastRowNumber == oldRowsCount
                    )
                {
                    return;
                }
            }

            InActionLog?.Invoke($"{DateTime.Now} | {Path.Combine(layer.RelativePath, layer.FileName)} | {type}");

            LayerApplier.Apply(StateStorage, layer);
            LayerProvider.SaveLayer(Settings.LayersDir, layer);
        }


        /// <summary>
        /// Инициализация хранилища состояния файлов и папок программы
        /// </summary>
        private void InitIfNeed()
        {
            if (!Settings.SrcFilesDir.Exists)
            {
                Settings.SrcFilesDir.Create();

                DirectoryInfo observableDir = new DirectoryInfo(Settings.ObservedDirectoryPath);
                var files = observableDir.GetFiles("*.txt", SearchOption.AllDirectories);

                foreach (var elem in files)
                {
                    var elemRelativePath = RelativePathFinder
                        .GetRelativePath(elem.FullName, observableDir.FullName);

                    var newPath = Path.Combine(
                        Settings.SrcFilesDir.FullName,
                        elemRelativePath,
                        elem.Name
                        );

                    var dataRows = FileProvider.TryReadAllLines(elem.FullName);
                    FileProvider.CreateWithDirectory(newPath, () => { File.WriteAllLines(newPath, dataRows); });
                    //File.WriteAllLines(newPath, dataRows);


                    StateStorage.FilesData.Add(
                        Path.Combine(elemRelativePath, elem.Name),
                        new StorageData()
                        {
                            //FullName = newPath,
                            Name = elem.Name,
                            Relative = elemRelativePath,
                            Text = dataRows
                        });
                }
            }
            else
            {
                StateStorage = StorageProvider
                    .ReadStorage(Settings.SrcFilesDir);

                var allLayers = LayerProvider
                    .GetAllLayers(Settings.LayersDir);

                allLayers.ToList()
                    .ForEach(
                    e => StateStorage = LayerApplier.Apply(StateStorage, e)
                    );
            }


            if (!Settings.LayersDir.Exists)
            {
                Settings.LayersDir.Create();
            }
        }


        #region

        private bool IsDisposed = false;

        protected void Dispose(bool disposing)
        {
            if (IsDisposed) return;
            if (disposing)
            {
                DirectoryWatcher.Dispose();
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
