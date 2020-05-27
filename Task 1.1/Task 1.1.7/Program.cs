using System;

namespace Task_1._1._7
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
                Console.WriteLine("1.1.7. Array processing" + Environment.NewLine);
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
                        RandomArray[i] = rand.Next(-10000, 9999);       //установка границ массива
                                                                        //для читабельности вывода

                    Console.WriteLine("Сгенерированный массив:");       //вывод полученного массива
                    OutputArray(RandomArray);                           
                    Console.WriteLine(Environment.NewLine);

                    Console.WriteLine("Минимальное значение в массиве: " + FindMinInArray(RandomArray));
                    Console.WriteLine("Максимальное значение в массиве: " + FindMaxInArray(RandomArray));
                    Console.Write(Environment.NewLine);

                    InsertionSort(RandomArray);                         //сортировка массива вставками

                    Console.WriteLine("Отсортированный массив:");       //вывод отсортированного массива
                    OutputArray(RandomArray);
                    break;
                }
            }
        }

        static void OutputArray(int[] array)                            //вывод массива
        {
            for (int i = 0; i < array.Length; i++)        
                Console.Write(array[i] + " ");
        }

        static int FindMaxInArray(int[] array)                          //поиск максимального числа в массиве
        {
            int max = Int32.MinValue;

            for (int i = 0; i < array.Length; i++)
                if (array[i] > max)
                    max = array[i];

            return max;
        }

        static int FindMinInArray(int[] array)                          //поиск минимального числа в массиве
        {
            int min = Int32.MaxValue;

            for (int i = 0; i < array.Length; i++)
                if (array[i] < min)
                    min = array[i];

            return min;
        }

        static void InsertionSort(int[] array)                 //сортировка вставками
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = key;
            }
        }
    }
}
