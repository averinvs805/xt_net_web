using System;

namespace Task_1._1._10
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows, columns;
            string input;
            Random rand = new Random();

            while (true)
            {
                Console.WriteLine("1.1.10. 2D Array" + Environment.NewLine);
                Console.Write("Введите число строк генерируемого двумерного массива: ");
                input = Console.ReadLine();                             //считывание числа строк и столбцов в массиве
                Int32.TryParse(input, out rows);

                Console.Write("Введите число столбцов генерируемого двумерного массива: ");
                input = Console.ReadLine();                             
                Int32.TryParse(input, out columns);
                Console.Write(Environment.NewLine);

                if (rows <= 0 || columns <= 0)                              //проверка считанного числа
                {
                    Console.WriteLine("Некорректные входные данные.\nНажмите любую клавишу...");
                    Console.ReadKey();                                      //выводится сообщение об ошибке,
                    Console.Clear();                                        //если на входе не положительное число
                }
                else
                {
                    int[,] RandomArray = new int[rows, columns];
                    for (int i = 0; i < rows; i++)                          //заполнение случайными числами и
                        for (int j = 0; j < columns; j++)
                            RandomArray[i, j] = rand.Next(-10000, 9999);    //установка границ массива для читабельности вывода

                    Console.WriteLine("Сгенерированный массив:");           //вывод полученного массива
                    for (int i = 0; i < RandomArray.GetLength(0); i++)
                    {
                        for (int j = 0; j < RandomArray.GetLength(1); j++)
                            Console.Write(RandomArray[i, j] + " ");
                        Console.Write(Environment.NewLine);
                    }

                    Console.WriteLine(Environment.NewLine + "Сумма всех элементов массива на четных позициях: " + 
                        SumOfEvenElements(RandomArray));

                    break;
                }
            }
        }

        static int SumOfEvenElements(int[,] array)                  
        {
            int sum = 0;

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    if ((i + j) % 2 == 0)
                        sum += array[i, j];

            return sum;
        }
    }
}
