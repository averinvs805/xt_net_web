using System;

namespace Task_1._1._6
{
    class Program
    {
        static void Main(string[] args)
        {
            int input;
            bool flag = true;

            Console.WriteLine("1.1.6. Font adjustment" + Environment.NewLine);

            var fonts = FontFlags.NoStyle;

            while (flag)
            {
                Console.WriteLine("Параметры надписи: " + fonts);
                Console.WriteLine("Введите:\n    1. Bold\n    2. Italic\n    3. Underline\n    -1. Выход из программы");

                Int32.TryParse(Console.ReadLine(), out input);

                switch (input)
                {
                    case -1:
                        flag = false;
                        break;
                    case 1:
                        fonts ^= FontFlags.Bold;
                        break;
                    case 2:
                        fonts ^= FontFlags.Italic;
                        break;
                    case 3:
                        fonts ^= FontFlags.Underline;
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод.");
                        break;
                }
                Console.WriteLine();
            }
        }

        [Flags]
        public enum FontFlags
        {
            NoStyle     =   0,
            Bold        =   1,
            Italic      =   2,
            Underline   =   4
        }
    }
}

