using System;

namespace Task_1._1._5
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            Console.WriteLine("1.1.5. Sum of numbers" + Environment.NewLine);
            Console.Write("Сумма всех натуральных чисел меньше 1000, кратных 3 или 5, равна:");

            for (int i = 1; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;
            }

            Console.Write(sum);
        }
    }
}
