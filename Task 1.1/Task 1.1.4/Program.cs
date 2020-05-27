using System;

namespace Task_1._1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int N;

            while (true)
            {
                Console.WriteLine("1.1.4. X-Mas Tree" + Environment.NewLine);
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
                        for (int j = 1; j <= i; j++)
                        {
                            string row = "";

                            for (int k = 1; k <= 2 * j - 1; k++)
                            {
                                row += "*";
                            }
                            
                            row = row.PadLeft(N + j - 1);
                            Console.WriteLine(row);
                        }
                    }
                    break;
                }
            }
        }
    }
}
