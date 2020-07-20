using System;
using System.Linq;

namespace Task_3._2._Dynamic_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> array = new DynamicArray<int>(Enumerable.Range(25, 75).ToArray());
            Console.WriteLine(array.Count);
            Console.WriteLine(array.Capacity);

            for (int item = 0; item < array.Count; item++)
            {
                Console.WriteLine(array[item]);
            }
            Console.WriteLine(array.Count);


            array.Insert(74, 2);
            array.Remove(55);

            Console.WriteLine(array.Count);
            Console.WriteLine(array.Capacity);

            for (int item = 0; item < array.Count; item++)
            {
                Console.WriteLine(array[item]);
            }

            Console.WriteLine(array.Count);
        }
    }
}
