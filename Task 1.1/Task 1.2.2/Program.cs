using System;

namespace Task_1._2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.2.2. Doubler");

            string input, doubler, result = "";

            Console.WriteLine("Введите первую строку:");
            input = Console.ReadLine();

            Console.WriteLine("Введите вторую строку:");
            doubler = Console.ReadLine();

            foreach (char c in input)
            {
                if (doubler.Contains(c))
                    result = result + c + c;
                else
                    result += c;
            }

            Console.WriteLine("Вывод: " + result);
        }
    }
}
