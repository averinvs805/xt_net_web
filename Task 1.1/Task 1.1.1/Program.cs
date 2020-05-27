using System;

namespace Task_1._1._1
{
    class Program
    {
        static void Main(string[] args)
        {

            string input;
            int a = 0, b = 0;

            Console.WriteLine("1.1.1. Rectangle" + Environment.NewLine);
            Console.WriteLine("Введите стороны прямоугольника для расчета площади:");

            Console.Write("a = ");
            input = Console.ReadLine();
            Int32.TryParse(input, out a);

            Console.Write("b = ");
            input = Console.ReadLine();
            Int32.TryParse(input, out b);

            if (a <= 0 || b <= 0)
                Console.WriteLine("Введено некорректное значение одной из сторон прямоугольника.");
            else
                Console.WriteLine("Площадь прямоугольника со сторонами " + a + " и " + b + " равна " + (a * b));

        }
    }
}
