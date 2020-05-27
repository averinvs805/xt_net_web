using System;

namespace Task_1._1._9
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            string input;
            Random rand = new Random();

            while (true)
            {
                Console.WriteLine("1.1.9. Non-negative sum" + Environment.NewLine);
                Console.Write("Введите число элементов генерируемого массива: ");
                input = Console.ReadLine();                             //считывание числа элементов в массиве
                Int32.TryParse(input, out n);

                if (n <= 0)                                             //проверка считанного числа
                {
                    Console.WriteLine("Некорректные входные данные.\nНажмите любую клавишу...");
                    Console.ReadKey();                                  //выводится сообщение об ошибке,
                    Console.Clear();                                    //если на входе не положительное число
                }
                else
                {
                    int[] RandomArray = new int[n];
                    for (int i = 0; i < n; i++)                         //заполнение случайными числами и
                        RandomArray[i] = rand.Next(-10000, 9999);       //установка границ массива для читабельности вывода

                    Console.WriteLine("Сгенерированный массив:");       //вывод полученного массива
                    for (int i = 0; i < RandomArray.Length; i++)
                        Console.Write(RandomArray[i] + " ");
                    Console.WriteLine(Environment.NewLine);

                    Console.WriteLine("Сумма всех неотрицательных элементов массива: " + NonNegativeSum(RandomArray));

                    break;
                }
            }
        }

        static int NonNegativeSum(int[] array)                          //вычисление суммы всех неотрицательных элементов
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
                if (array[i] >= 0)
                    sum += array[i];

            return sum;
        }
    }
}
