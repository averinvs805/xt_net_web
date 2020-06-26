using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Task_2._1_OOP
{
    public class CustomString : IComparable<CustomString>
    {
        private char[] characters;

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
            if (obj.GetType().Name == "CustomString")
            {
                CustomString other = (CustomString)obj;

                if (this.characters.Length != other.characters.Length)
                {
                    return false;
                }

                for (int i = 0; i < this.characters.Length; i++)
                {
                    if (this.characters[i] != other.characters[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public static bool operator ==(CustomString str1, CustomString str2)
        {
            return str1.Equals(str2);
        }

        public static bool operator !=(CustomString str1, CustomString str2)
        {
            return !str1.Equals(str2);
        }

        public static CustomString operator +(CustomString str1, CustomString str2)
        {
            char[] concat_array = new char[str1.characters.Length + str2.characters.Length];

            str1.characters.CopyTo(concat_array, 0);
            str2.characters.CopyTo(concat_array, str1.characters.Length);

            return new CustomString(concat_array);
        }

        public static bool operator >(CustomString str1, CustomString str2)
        {
            return str1.CompareTo(str2) > 0;
        }

        public static bool operator <(CustomString str1, CustomString str2)
        {
            return str1.CompareTo(str2) < 0;
        }

        public static bool operator <=(CustomString str1, CustomString str2)
        {
            return str1.CompareTo(str2) <= 0;
        }

        public static bool operator >=(CustomString str1, CustomString str2)
        {
            return str1.CompareTo(str2) >= 0;
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

            return -1;
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

        public int CompareTo([AllowNull] CustomString other)
        {
            if (this.characters.Length > other.characters.Length)
            {
                return 1;
            }
            if (this.characters.Length < other.characters.Length)
            {
                return -1;
            }

            for (int i = 0; i < this.characters.Length; i++)
            {
                if (this.characters[i] > other.characters[i])
                {
                    return 1;
                }
                if (this.characters[i] < other.characters[i])
                {
                    return -1;
                }
            }

            return 0;
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
}
