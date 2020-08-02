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
    public class StorageProvider
    {
        private readonly RelativePathFinder RelativePathFinder
            = new RelativePathFinder();

        private readonly FileProvider FileProvider
            = new FileProvider();

        public string Fileter { set; get; } = "*.txt";

        public StateStorage ReadStorage(DirectoryInfo rootDirectory)
        {
            StateStorage storage = new StateStorage();

            var files = rootDirectory.GetFiles(Fileter, SearchOption.AllDirectories);

            foreach (var elem in files)
            {
                var elemRelativePath = RelativePathFinder
                    .GetRelativePath(elem.FullName, rootDirectory.FullName);

                storage.FilesData.Add(
                    Path.Combine(elemRelativePath, elem.Name),
                    new StorageData()
                    {
                        //FullName = elem.FullName,                           
                        Name = elem.Name,
                        Relative = elemRelativePath,
                        Text = FileProvider.TryReadAllLines(elem.FullName)
                    });
            }

            return storage;
        }
        public void WriteStorage(DirectoryInfo directory, StateStorage storage)
        {
            directory
                .GetFiles(Fileter, SearchOption.AllDirectories)
                .ToList()
                .ForEach(
                    e => e.Delete()
                );

            foreach (var elem in storage.FilesData)
            {
                var fullPath = Path.Combine(directory.FullName, elem.Value.Relative, elem.Value.Name);

                FileProvider.CreateWithDirectory(fullPath, () => { File.WriteAllLines(fullPath, elem.Value.Text); });
            }
        }

    }
}
