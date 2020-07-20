using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3._3._2._Super_String
{
    public static class SuperString
    {
        public static string StringType(this string src)
        {

            Dictionary<string, Tuple<int, int>> groups
                = new Dictionary<string, Tuple<int, int>>()
                {
                    ["Russian"] = new Tuple<int, int>('а', 'ё'),
                    ["English"] = new Tuple<int, int>('a', 'z'),
                    ["Number"] = new Tuple<int, int>('0', '9'),
                };

            foreach (var group in groups)
            {
                if (src.All(e => e >= group.Value.Item1 && e <= group.Value.Item2))
                {
                    return group.Key;
                }
            }

            return "Mixed";

            #region old
            //if (src.All(e => e >= 'a' && e <= 'z'))
            //{
            //    return "English";
            //}
            //else if (src.All(e => e >= 'а' && e <= 'ё'))
            //{
            //    return "Russian";
            //}
            //else if (src.All(e => e >= '0' && e <= '9'))
            //{
            //   return "Number";
            //}
            //else
            //{
            //    return "Mixed";
            //}
            #endregion
        }
    }
}
