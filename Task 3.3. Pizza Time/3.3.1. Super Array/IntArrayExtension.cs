using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3._3._1._Super_Array
{
    static class IntArrayExtension
    {
        public static void ForEach(this int[] arr, Func<int, int> action)
        {
            foreach (var elem in arr)
            {
                action(elem);
            }
        }



        public static int SumItems(this int[] arr) =>
            arr?.Sum()
            ?? throw new NullReferenceException();

        public static double AverageItems(this int[] arr) =>
            arr?.Average()
            ?? throw new NullReferenceException();

        public static int? MaxRepeatItem(this int[] arr) =>
            arr?
            .GroupBy(e => e)
            .OrderByDescending(e => e.Count())
            .FirstOrDefault()?
            .Key;

    }
}
