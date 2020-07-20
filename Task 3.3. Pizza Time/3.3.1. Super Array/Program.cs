using System;

namespace _3._3._1._Super_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[30];

            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            { 
                array[i] = rnd.Next(-10, 10);
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();

            Console.WriteLine("Сумма всех элементов: " + array.SumItems());
            Console.WriteLine("Среднее значение всех элементов: " + array.AverageItems());
            Console.WriteLine("Самый часто встречающийся элемент: " + array.MaxRepeatItem());

            array.ForEach(a => a * 3);

            Console.WriteLine("Массив после действия:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
        }
    }
}
