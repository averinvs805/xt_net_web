using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml.Serialization;

namespace Task_4._1._Files
{
    /// <summary>
    /// Изменения в слое
    /// </summary>
    class LayerInfo
    {
        /// <summary>
        /// Дата изменения (служит ключем)
        /// </summary>
        public DateTime EventDate { set; get; }

        /// <summary>
        /// Имя файла
        /// </summary>
        public string FileName { set; get; }

        /// <summary>
        /// Новое имя файла (только при переименовании)
        /// </summary>
        public string NewName { set; get; }

        /// <summary>
        /// Относительный путь относительно наблюдаемой папки
        /// </summary>
        public string RelativePath { set; get; }

        /// <summary>
        /// Тип изменения
        /// </summary>
        public WatcherChangeTypes ChangeType { set; get; }

        /// <summary>
        /// Набор изменении внутри содержимого файла
        /// </summary>
        public AddOrUpdateData AddOrUpdateData { set; get; }

    }


    /// <summary>
    /// Провайдер для чтения/записи данных о слое
    /// </summary>
    class LayerProvider
    {
        private readonly string LayerPrefix = "Layer_";

        private readonly string DeletePrefix = "Delete_";
        private readonly string RenamePrefix = "Rename_";


        private DirectoryInfo LayersDir;

        public LayerProvider(DirectoryInfo layersDir)
        {
            LayersDir = layersDir;
        }

        public void SaveLayer(LayerInfo layer)
        {
            var layerDir = LayersDir
                .CreateSubdirectory(LayerPrefix + layer.EventDate.ToLongTimeString());

            var path = Path.Combine(layerDir.FullName, layer.RelativePath);

            switch (layer.ChangeType)
            {
                case WatcherChangeTypes.Deleted:
                    path = Path.Combine(path, $"{DeletePrefix}{layer.FileName}");
                    File.Create(path);
                    break;
                case WatcherChangeTypes.Renamed:
                    path = Path.Combine(path, $"{RenamePrefix}{layer.FileName}_{layer.NewName}");
                    File.Create(path);
                    break;
                default:
                    path = Path.Combine(path, layer.FileName);
                    File.Create(path);

                    XmlSerializer formatter = new XmlSerializer(typeof(AddOrUpdateData));

                    using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, layer.AddOrUpdateData);
                    }

                    break;
            }

        }
        public LayerInfo LoadLayer(string directoryName)
        {
            var layerDir = new DirectoryInfo(Path.Combine(LayersDir.FullName, directoryName));
            var eventFile = layerDir.GetFiles("*", SearchOption.AllDirectories).First();

            var eventDate = DateTime.Parse(
                        directoryName.Substring(LayerPrefix.Length)
                        );


            if (eventFile.Name.StartsWith(DeletePrefix))
            {
                var nameData = eventFile.Name.Split('_');

                return new LayerInfo()
                {
                    EventDate = eventDate,
                    ChangeType = WatcherChangeTypes.Deleted,
                    FileName = nameData[1]
                };
            }
            else if (eventFile.Name.StartsWith(RenamePrefix))
            {
                var nameData = eventFile.Name.Split('_');

                return new LayerInfo()
                {
                    EventDate = eventDate,
                    ChangeType = WatcherChangeTypes.Renamed,
                    FileName = nameData[1],
                    NewName = nameData[2]
                };
            }
            else
            {
                using (FileStream fs = new FileStream(eventFile.FullName, FileMode.Open))
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(AddOrUpdateData));
                    AddOrUpdateData addOrUpdateData = (AddOrUpdateData)formatter.Deserialize(fs);


                    return new LayerInfo()
                    {
                        EventDate = eventDate,
                        ChangeType = WatcherChangeTypes.Changed,
                        FileName = eventFile.Name,
                        AddOrUpdateData = addOrUpdateData,
                    };
                }
            }
        }


        public LayerInfo[] GetAllLayers()
        {
            var layersNames = LayersDir
                .GetDirectories("*", SearchOption.TopDirectoryOnly)
                .Where(e => e.Name.StartsWith(LayerPrefix))
                .ToArray();

            LayerInfo[] layers = new LayerInfo[layersNames.Length];

            for (int i = 0; i < layersNames.Length; i++)
            {
                layers[i] = LoadLayer(layersNames[i].Name);
            }

            layers = layers
                .OrderBy(e => e.EventDate)
                .ToArray();

            return layers;
        }


    }



}
