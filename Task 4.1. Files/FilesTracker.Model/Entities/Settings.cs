using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace FilesTracker.Model.Entities
{
    public class Settings
    {

        public string ObservedDirectoryPath
        {
            set => ObservDir = new DirectoryInfo(value);
            get => ObservDir.FullName;
        }
        public string WorkDirectoryPath
        {
            set
            {
                WorkDir = new DirectoryInfo(value);
                SrcFilesDir = new DirectoryInfo(Path.Combine(value, SrcFileDirectoryName));
                LayersDir = new DirectoryInfo(Path.Combine(value, LayersDirectoryPathName));
            }
            get => ObservDir.FullName;
        }


        private readonly string SrcFileDirectoryName = "SrcFiles";
        private readonly string LayersDirectoryPathName = "Layers";


        public DirectoryInfo ObservDir { private set; get; }
        public DirectoryInfo WorkDir { private set; get; }
        public DirectoryInfo SrcFilesDir { private set; get; }
        public DirectoryInfo LayersDir { private set; get; }

    }
}
