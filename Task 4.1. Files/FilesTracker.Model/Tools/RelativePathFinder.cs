using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesTracker.Model.Tools
{
    public class RelativePathFinder
    {
        public string GetRelativePath(string filFullPaht, string directory)
        {
            var filePathSections = filFullPaht.Split('\\');
            var directoryPathSections = directory.Split('\\');

            if (filePathSections[0] != directoryPathSections[0])
            {
                throw new Exception();
            }


            StringBuilder result = new StringBuilder();

            //int i = 0;
            //for (i = 0; filePathSections[i] == directoryPathSections[i]; i++)
            //{ 

            //}

            for (int i = directoryPathSections.Length; i < filePathSections.Length - 1; i++)
            {
                result.Append($"\\{filePathSections[i]}");
            }

            return result
                .ToString()
                .Trim('\\');
        }
    }
}
