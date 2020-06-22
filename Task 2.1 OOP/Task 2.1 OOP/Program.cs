using System;

namespace Task_2._1_OOP
{
    public class CustomString
    {
        public char[] characters;

        public CustomString(string text)
        {
            this.characters = text.ToCharArray();
        }
        public CustomString(char[] chars)
        {
            this.characters = chars;
        }

        public override string ToString()
        {
            return new string(this.characters);
        }

        public char[] ToArray()
        {
            return characters;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public static bool operator ==(CustomString str1, CustomString str2)
        {
            if (str1.characters.Length != str2.characters.Length)
            {
                return false;
            }

            for (int i = 0; i < str1.characters.Length; i++)
            {
                if (str1.characters[i] != str2.characters[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator !=(CustomString str1, CustomString str2)
        {
            if (str1.characters.Length != str2.characters.Length)
            {
                return true;
            }

            for (int i = 0; i < str1.characters.Length; i++)
            {
                if (str1.characters[i] != str2.characters[i])
                {
                    return true;
                }
            }
            return false;
        }

        public static CustomString operator +(CustomString str1, CustomString str2)
        {
            return new CustomString(str1.ToString() + str2.ToString());
        }

        public static bool operator >(CustomString str1, CustomString str2)
        {
            if (str1.characters.Length > str2.characters.Length)
            {
                return true;
            }
            if (str1.characters.Length < str2.characters.Length)
            {
                return false;
            }

            for (int i = 0; i < str1.characters.Length; i++)
            {
                if (str1.characters[i] > str2.characters[i])
                {
                    return true;
                }
                if (str1.characters[i] < str2.characters[i])
                {
                    return false;
                }
            }

            return false;
        }

        public static bool operator <(CustomString str1, CustomString str2)
        {
            if (str1.characters.Length < str2.characters.Length)
            {
                return true;
            }
            if (str1.characters.Length > str2.characters.Length)
            {
                return false;
            }

            for (int i = 0; i < str1.characters.Length; i++)
            {
                if (str1.characters[i] < str2.characters[i])
                {
                    return true;
                }
                if (str1.characters[i] > str2.characters[i])
                {
                    return false;
                }
            }
            
            return false;
        }

        public static bool operator <=(CustomString str1, CustomString str2)
        {
            return str1.characters.Length <= str2.characters.Length;
        }

        public static bool operator >=(CustomString str1, CustomString str2)
        {
            return str1.characters.Length >= str2.characters.Length;
        }

        public int FirstIndexOf(char ch)
        {
            for (int i = 0; i < this.characters.Length; i++)
            {
                if (this.characters[i] == ch)
                {
                    return i;
                }
            }

            return -1;
        }

        public int IndexOf(char c)
        {
            for (int i = 0; i < this.characters.Length; i++)
            {
                if (this.characters[i] == c)
                {
                    return i;
                }
            }

            return - 1;
        }

        public int LastIndexOf(char c)
        {
            int index = -1;

            for (int i = 0; i < this.characters.Length; i++)
            {
                if (this.characters[i] == c)
                {
                    index = i;
                }
            }

            return index;
        }

        public char this[int index]
        {
            get
            {
                return characters[index];
            }
            set
            {
                characters[index] = value;
            }
        }
    }

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
