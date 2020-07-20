using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task_3._2._Dynamic_Array
{
    class DynamicArrayEnumerator<T>
            :
            IEnumerator,
            IEnumerator<T>
    {
        private readonly DynamicArray<T> DynamicArray;
        private int CurrentPosition = 0;


        public DynamicArrayEnumerator(DynamicArray<T> array)
        {
            DynamicArray = array;
        }


        T Current => DynamicArray[CurrentPosition];
        T IEnumerator<T>.Current => DynamicArray[CurrentPosition];
        object IEnumerator.Current => DynamicArray[CurrentPosition];





        public bool MoveNext()
        {
            CurrentPosition++;

            if (CurrentPosition < DynamicArray.Length)
            {
                return true;
            }

            return false;
        }

        public void Reset()
        {
            CurrentPosition = 0;
        }


        public void Dispose()
        {
            //throw new NotImplementedException();
        }

    }
}
