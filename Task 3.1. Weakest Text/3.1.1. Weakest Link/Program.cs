using System;

namespace Task_3._1._Weakest_Text
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Введите количество людей:");

                int.TryParse(Console.ReadLine(), out int N);

                if (N > 0)
                {
                    Console.WriteLine("Введите шаг:");

                    int.TryParse(Console.ReadLine(), out int step);

                    if (step > 1)
                    {
                        Game.RunGame(N, step);
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Шаг должен быть больше 1. Нажмите любую клавишу...");
                    }
                }
                else
                {
                    Console.WriteLine("Число игроков должно быть положительным. Нажмите любую клавишу...");
                }

                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
