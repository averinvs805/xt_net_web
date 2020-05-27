using System;

namespace Task_1._1._8
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows, columns, matrices;
            string input;

            while (true)
            {
                Console.WriteLine("1.1.8. No positive" + Environment.NewLine);

                Console.Write("Введите количество матриц в трехмерном массиве: ");
                input = Console.ReadLine();
                Int32.TryParse(input, out matrices);

                Console.Write("Введите количество строк в трехмерном массиве: ");
                input = Console.ReadLine();
                Int32.TryParse(input, out rows);

                Console.Write("Введите количество столбцов в трехмерном массиве: ");
                input = Console.ReadLine();
                Int32.TryParse(input, out columns);
                Console.WriteLine();

                if (rows <= 0 || columns <= 0 || matrices <= 0)
                {
                    Console.WriteLine("Некорректные входные данные.\nНажмите любую клавишу...");
                    Console.ReadKey();                                          //выводится сообщение об ошибке
                    Console.Clear();                                            //если на входе не положительные числа
                }
                else
                {
                    int[,,] RandomArray = CreateArray(matrices, rows, columns);

                    Console.WriteLine("Сгенерированный массив:" + Environment.NewLine);
                    OutputArray(RandomArray);

                    for (int i = 0; i < matrices; i++)                          //заполнение случайными числами и
                        for (int j = 0; j < rows; j++)                          //установка границ массива
                            for (int k = 0; k < columns; k++)
                                if (RandomArray[i, j, k] > 0)
                                    RandomArray[i, j , k] = 0;

                    Console.WriteLine("Массив без положительных чисел:" + Environment.NewLine);
                    OutputArray(RandomArray);
                    break;
                }
            }
        }

        static int[,,] CreateArray(int matrices, int rows, int columns)
        {
            Random rand = new Random();
            int[,,] array = new int[matrices, rows, columns];

            for (int i = 0; i < matrices; i++)                                  //заполнение случайными числами и
                for (int j = 0; j < rows; j++)                                  //установка границ массива
                    for (int k = 0; k < columns; k++)
                        array[i, j, k] = rand.Next(-10000, 9999);
            
            return array;
        }

        static void OutputArray(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int num = i + 1;
                Console.WriteLine("Матрица " + num + ":");

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        string str = array[i, j, k].ToString();
                        str = str.PadRight(6);
                        Console.Write(str);
                    }
                    Console.Write(Environment.NewLine);
                }

                Console.Write(Environment.NewLine);
            }
        }
    }
}
