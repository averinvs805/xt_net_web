using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3._3._1._Super_Array
{
    static class DoubleArrayExtension
    {
        public static void ForEach(this double[] arr, Action<double> action)
        {
            foreach (var elem in arr)
            {
                action(elem);
            }
        }



        public static double SumItems(this double[] arr) =>
            arr?.Sum()
            ?? throw new NullReferenceException();

        public static double AverageItems(this double[] arr) =>
            arr?.Average()
            ?? throw new NullReferenceException();

        public static double? MaxRepeatItem(this double[] arr) =>
            arr?
            .GroupBy(e => e)
            .OrderByDescending(e => e.Count())
            .FirstOrDefault()?
            .Key;


    }
}
