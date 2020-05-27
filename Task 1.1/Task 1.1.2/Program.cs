using System;

namespace Task_1._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int N;

            while (true)
            {
                Console.WriteLine("1.1.2. Triangle" + Environment.NewLine);
                Console.Write("Введите положительное число N:\nN = ");
                input = Console.ReadLine();
                Int32.TryParse(input, out N);
                if (N <= 0)
                {
                    Console.WriteLine("N должно быть положительным числом.");
                    Console.WriteLine("Нажмите любую клавишу...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    for (int i = 1; i <= N; i++)
                    {
                        string row = new String('*', i);
                        Console.WriteLine(row);
                    }
                    break;
                }
            }
        }
    }
}
