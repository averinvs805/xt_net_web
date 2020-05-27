using System;

namespace Task_1._2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            double count = 0, sum = 0, average;

            while (true)
            {
                Console.WriteLine("1.2.1. Averages" + Environment.NewLine);

                Console.WriteLine("Введите текстовую строку для расчета средней длины слова:");
                input = Console.ReadLine();

                if (input == "")
                {
                    Console.WriteLine("Поле ввода пустое. \nНажмите любую клавишу...");
                    Console.ReadKey();                                                  //выводится сообщение об ошибке,
                    Console.Clear();                                                    //если на входе пусто
                }
                else
                {
                    string[] words = input.Split(new char[] { ' ', '.', ',', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
                                                                                        //строка разбивается на слова
                    Console.WriteLine(Environment.NewLine + "Слова в строке:");
                    foreach (var elem in words)
                    {
                        count++;
                        sum += elem.Length;
                        Console.WriteLine(elem);
                    }
                    Console.WriteLine();


                    average = sum / count;
                    average = Math.Round(average, 3);                                   //средняя длина округляется до 3 знаков после запятой

                    Console.WriteLine("Средняя длина слова во введенной строке равна " + average);

                    break;
                }
            }
        }
    }
}
