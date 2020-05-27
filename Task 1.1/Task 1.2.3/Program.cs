using System;

namespace Task_1._2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int count = 0;

            while (true)
            {
                Console.WriteLine("1.2.2. Lowercase" + Environment.NewLine);

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

                    Console.WriteLine();
                    foreach (var elem in words)
                    {
                        if (!char.IsUpper(elem[0]))
                            count++;
                        Console.WriteLine(elem);
                    }
                    Console.WriteLine();

                    Console.WriteLine("Количество слов, начинающихся с маленькой буквы:" + count);

                    break;
                }
            }
        }
    }
}
