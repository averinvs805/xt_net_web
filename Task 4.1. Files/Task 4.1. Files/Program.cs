using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml.Serialization;

namespace Task_4._1._Files
{

    public class Settings
    {

        public string ObservDirectoryPath { set; get; }
        public string WorkDirectoryPath { set; get; }


        public readonly string SrcFileDirectoryPath = "SrcFile";
        public readonly string LayersDirectoryPath = "Layers";


        public DirectoryInfo WorkDir { private set; get; }
        public DirectoryInfo SrcFilesDir { private set; get; }
        public DirectoryInfo LayersDir { private set; get; }


        public Settings()
        {
            WorkDir = new DirectoryInfo(WorkDirectoryPath);
            SrcFilesDir = new DirectoryInfo(Path.Combine(WorkDirectoryPath, SrcFileDirectoryPath));
            LayersDir = new DirectoryInfo(Path.Combine(WorkDirectoryPath, LayersDirectoryPath));
        }

    }


    class LayerApplier
    {
        public StateStorage Apply(StateStorage storage, LayerInfo layer)
        {
            //switch (layer.ChangeType) 
            //{
            //    case WatcherChangeTypes.Deleted:
            //        storage.FilesData.Remove();
            //        break;
            //    case WatcherChangeTypes.Renamed:
            //        storage.FilesData.Add();
            //        storage.FilesData.Remove();
            //        break;
            //    case WatcherChangeTypes.Changed:
            //        if (!storage.FilesData.ContainsKey())
            //        {
            //            storage.FilesData.Add();
            //        }
            //        else 
            //        {
            //            storage.FilesData[""] = ;
            //        }
            //        break;
            //}



            return storage;
        }
    }


    class Program
    {


        static void Main(string[] args)
        {

            //using (DirectoryTrackSystem trackSystem = new DirectoryTrackSystem()) 
            //{

            //}
        }
    }
}
