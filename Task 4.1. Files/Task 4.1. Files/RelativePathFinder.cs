using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._1._Files
{
    public class RelativePathFinder
    {
        public string GetRelativePath(string filFullPaht, string directory)
        {
            var pathSections = filFullPaht.Split('\\');
            string result = "";

            //Начинам со 2 секции, игнорируем имя файла
            for (int i = pathSections.Length - 2; !pathSections[i].Equals(directory, StringComparison.OrdinalIgnoreCase); i--)
            {
                if (i == 0)
                {
                    throw new Exception();
                }

                result = $"\\{pathSections[i]}" + result;
            }

            return result;
        }
    }
}
