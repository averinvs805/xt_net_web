using System;

namespace Task_1._1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int N;

            while (true)
            {
                Console.WriteLine("1.1.3. Another triangle" + Environment.NewLine);
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
                        string row = "";
                        for (int j = 1; j <= 2*i-1; j++)
                        {
                            row += "*";
                        }
                        row = row.PadLeft(N + i - 1);
                        Console.WriteLine(row);
                    }
                    break;
                }
            }
        }
    }
}
