using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._1._Files
{
    /// <summary>
    /// Система поиска отличий между двумя наборами строк
    /// </summary>
    public class TextDifference
    {
        public AddOrUpdateData Different(string[] text1, string[] text2)
        {
            List<RowInformation> changes = new List<RowInformation>(text2.Length);

            for (int i = 0; i < text1.Length && i < text2.Length; i++)
            {
                if (text1[i] != text2[i])
                {
                    changes.Add(new RowInformation()
                    {
                        RowNumber = i,
                        Context = text2[i]
                    });
                }
            }

            return new AddOrUpdateData()
            {
                ChangesRows = changes,
                LastRowNumber = text2.Length
            };
        }

    }
}
