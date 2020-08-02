using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Globalization;
using System.Xml.Serialization;

using FilesTracker.Model.Entities;
using FilesTracker.Model.Tools;
using FilesTracker.Model.DAL;

namespace FilesTracker.Model
{



    /// <summary>
    /// Провайдер для чтения/записи данных о слое
    /// </summary>
    public class LayerProvider
    {
        private readonly string LayerPrefix = "Layer_";

        private readonly string DeletePrefix = "Delete_";
        private readonly string RenamePrefix = "Rename_";

        private readonly string TimeStampFormat = "yyyy.MM.dd HH.mm.ss.ffffff";


        private readonly RelativePathFinder RelativePathFinder 
            = new RelativePathFinder();

        private readonly FileProvider FileProvider 
            = new FileProvider();


        public void SaveLayer(DirectoryInfo layersDir, LayerInfo layer)
        {
            var layerDir = layersDir
                .CreateSubdirectory(LayerPrefix + layer.EventDate.ToString(TimeStampFormat));

            var path = Path.Combine(layerDir.FullName, layer.RelativePath);

            switch (layer.ChangeType)
            {
                case WatcherChangeTypes.Deleted:
                    path = Path.Combine(path, $"{DeletePrefix}{layer.FileName}");
                    FileProvider.CreateWithDirectory(path, null);
                    break;
                case WatcherChangeTypes.Renamed:
                    path = Path.Combine(path, $"{RenamePrefix}{layer.FileName}_{layer.NewName}");
                    FileProvider.CreateWithDirectory(path, null);
                    break;
                default:
                    path = Path.Combine(path, layer.FileName);
                    XmlSerializer formatter = new XmlSerializer(typeof(AddOrUpdateData));

                    FileProvider.CreateWithDirectory(path, 
                        () =>
                    {
                        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            formatter.Serialize(fs, layer.AddOrUpdateData);
                        }
                    });              

                    break;
            }

        }
        public LayerInfo LoadLayer(DirectoryInfo layersDir, string directoryName)
        {
            var layerDir = new DirectoryInfo(Path.Combine(layersDir.FullName, directoryName));
            var eventFile = layerDir.GetFiles("*", SearchOption.AllDirectories).First();

            var timestamp = directoryName.Substring(LayerPrefix.Length);

            var eventDate = DateTime.ParseExact(
                timestamp,
                TimeStampFormat, 
                CultureInfo.InvariantCulture
            );


            if (eventFile.Name.StartsWith(DeletePrefix))
            {
                var nameData = eventFile.Name.Split('_');

                return new LayerInfo()
                {
                    EventDate = eventDate,
                    ChangeType = WatcherChangeTypes.Deleted,
                    FileName = nameData[1],
                    RelativePath = RelativePathFinder.GetRelativePath(eventFile.FullName, layerDir.FullName)
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
                    NewName = nameData[2],
                    RelativePath = RelativePathFinder.GetRelativePath(eventFile.FullName, layerDir.FullName)
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
                        RelativePath = RelativePathFinder.GetRelativePath(eventFile.FullName, layerDir.FullName)
                    };
                }
            }
        }

        public void DeleteLayer(DirectoryInfo layersDir, LayerInfo layer) 
        {
            var path = Path.Combine
                (
                    layersDir.FullName,
                    LayerPrefix + layer
                        .EventDate
                        .ToString(TimeStampFormat)                    
                );

            new DirectoryInfo(path)
                .Delete(true);
        }


        public LayerInfo[] GetAllLayers(DirectoryInfo layersDir) 
        {
            var layersNames = layersDir
                .GetDirectories("*", SearchOption.TopDirectoryOnly)
                .Where(e => e.Name.StartsWith(LayerPrefix))
                .ToArray();

            LayerInfo[] layers = new LayerInfo[layersNames.Length];

            for (int i = 0; i < layersNames.Length; i++)
            {
                layers[i] = LoadLayer(layersDir, layersNames[i].Name);
            }

            layers = layers
                .OrderBy(e => e.EventDate)
                .ToArray();

            return layers;
        }

    }



}
