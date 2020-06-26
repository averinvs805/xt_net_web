using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_2._1_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomString test_string1 = new CustomString(new char[] { 'T', 'e', 's', 't' });
            CustomString test_string2 = new CustomString("CustomString from a regular string");

            Console.WriteLine("Первая строка: " + test_string1);
            Console.WriteLine("Вторая строка: " + test_string2 + Environment.NewLine);

            Console.WriteLine("Равенство строк: " + (test_string1 == test_string2));
            
            Console.WriteLine("Первая строка больше второй: " + (test_string1 > test_string2));
            Console.WriteLine("Первая строка меньше второй: " + (test_string1 < test_string2));

            Console.WriteLine("Первая строка больше или равна второй: " + (test_string1 >= test_string2));
            Console.WriteLine("Первая строка меньше или равна второй: " + (test_string1 <= test_string2));

            CustomString concat = test_string1 + test_string2;
            Console.WriteLine("Конкатенация строк: " + concat);

            Console.WriteLine("Первое вхождение символа 's' в первой строке: " + test_string1.IndexOf('s'));
            Console.WriteLine("Последнее вхождение символа 's' во второй строке: " + test_string2.LastIndexOf('s'));

            Console.WriteLine("Десятый символ второй строки:" + test_string2[9]);

            char[] CustomStrToArray = test_string2.ToArray();
            Console.WriteLine("Представление в виде массива символов: ");
            for (int i = 0; i < CustomStrToArray.Length; i++)
            {
                Console.Write(CustomStrToArray[i] + " ");
            }
        }
    }
}
