using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_3._2._Dynamic_Array
{
    class DynamicArray<T> : IEnumerable, IEnumerable<T>, ICloneable
    {
        private T[] _data;


        public int Length { private set; get; } = 0;
        public int Capacity
        {
            set
            {
                if (value == Capacity)
                {
                    return;
                }

                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Вместимость массива не может быть отрицательной!");
                }

                var data = new T[value];

                if (value <= Length)
                {
                    Array.Copy(_data, data, value);
                }
                else
                {
                    Array.Copy(_data, data, Length);
                }

                _data = data;
            }
            get => _data.Length;
        }

        public int Count => Length;

        //11.	Индексатор, позволяющий работать с элементом с указанным номером. При выходе за границу массива должно 
        //      генерироваться исключение ArgumentOutOfRangeException.
        public T this[int index]
        {
            get
            {
                if (index >= 0)
                {
                    if (index < Length)
                    {
                        return _data[index];
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Индекс не должен выходить за пределы массива");
                    }
                }
                else
                {
                    if (index > -Length)
                    {
                        return _data[Length + index];
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Отрицательный индекс не должен выходить за пределы массива");
                    }
                }
            }

            set
            {
                if (index >= 0)
                {
                    if (index < Length)
                    {
                        _data[index] = value;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Индекс не должен выходить за пределы массива");
                    }
                }
                else
                {
                    if (index > -Length)
                    {
                        _data[Length + index] = value;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Отрицательный индекс не должен выходить за пределы массива");
                    }
                }

            }
        }


        #region consructors

        //1.+	Конструктор без параметров (создаётся массив ёмкостью 8 элементов).
        public DynamicArray()
        {
            _data = new T[8];
            Length = 0;
            Capacity = 8;
        }

        //2.+	Конструктор с одним целочисленным параметром (создаётся массив указанной ёмкости).
        public DynamicArray(int capacity)
        {
            _data = new T[capacity];
            Length = 0;
            Capacity = capacity;
        }

        //3.+	Конструктор, который в качестве параметра принимает коллекцию, реализующую интерфейс IEnumerable<T>, 
        //      создаёт массив нужного размера и копирует в него все элементы из коллекции.
        public DynamicArray(IEnumerable<T> data)
        {
            //_data = new T[data.Count()];

            //int i = 0;

            //foreach (var item in data)
            //{
            //    _data[i] = item;
            //    i++;
            //}

            _data = data.ToArray();
            Length = data.Count();
            Capacity = data.Count();
        }

        #endregion

        #region public

        //4.+	Метод Add, добавляющий в конец массива один элемент. При нехватке места для добавления элемента,
        //      ёмкость массива должна удваиваться.
        public void Add(T elem)
        {
            if (Length + 1 >= Capacity)
            {
                Capacity *= 2;
            }

            _data[Length] = elem;
            Length++;
        }

        //5.+	Метод AddRange, добавляющий в конец массива содержимое коллекции, реализующей интерфейс IEnumerable<T>. 
        //      Обратите внимание, метод должен корректно учитывать число элементов в коллекции с тем, чтобы при необходимости 
        //      расширения массива делать это только один раз вне зависимости от числа элементов в добавляемой коллекции.
        public void AddRange(IEnumerable<T> data)
        {
            if (Length + data.Count() > Capacity)
            {
                Capacity = Length + data.Count();
            }

            int i = Length;

            foreach (var item in data)
            {
                _data[i] = item;
                i++;
            }

            Length = i;
        }

        //6.+	Метод Remove, удаляющий из коллекции указанный элемент. Метод должен возвращать true, если удаление прошло успешно 
        //      и false в противном случае. При удалении элементов реальная ёмкость массива не должна уменьшаться.
        public bool Remove(T value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (value.Equals(_data[i]))
                {
                    for (int j = i; j < Length - 1; j++)
                    {
                        _data[j] = _data[j + 1];
                    }

                    _data[Length - 1] = default;
                    Length--;
                    
                    return true;
                }
            }

            return false;
        }

        //Почему бы и нет
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (index + 1 != Length - 1)
            {
                for (int i = index + 1; i + 1 < Length; i++)
                {
                    _data[i] = _data[i + 1];
                }
            }
            else
            {
                _data[index] = default;
            }

            Length--;
        }

        //7.+	Метод Insert, позволяющий добавить элемент в произвольную позицию массива (обратите внимание, может потребоваться 
        //      расширить массив). Метод должен возвращать true, если добавление прошло успешно и false в противном случае. 
        //      При выходе за границу массива должно генерироваться исключение ArgumentOutOfRangeException.
        public bool Insert(int index, T value)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException($"Нельзя вставить элемент по индексу {index}, выходящему за пределы массива.");
            }

            if (Length + 1 > Capacity)
            {
                Capacity *= 2;
            }

            for (int i = Length; i >= index + 1; i--)
            {
                _data[i] = _data[i - 1];
            }

            _data[index] = value;

            Length++;
            return true;
        }

        public object Clone()
        {
            var clonedArray = new DynamicArray<T>(Capacity);

            for (int i = 0; i < Length; i++)
            {
                clonedArray[i] = this[i];
            }

            clonedArray.Length = Length;

            return clonedArray;
        }

        public T[] ToArray()
        {
            T[] _newData = new T[Length];

            for (int i = 0; i < Length; i++)
            {
                _newData[i] = this[i];
            }
            return _newData;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DynamicArrayEnumerator<T>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new DynamicArrayEnumerator<T>(this);
        }

        #endregion


    }
}
