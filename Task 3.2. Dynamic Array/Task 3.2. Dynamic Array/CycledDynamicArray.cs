using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task_3._2._Dynamic_Array
{
    class CycledDynamicArray<T> : DynamicArray<T>, IEnumerable<T>
    {
        #region consructors

        public CycledDynamicArray() : base()
        {
        }
        public CycledDynamicArray(int capacity) : base(capacity)
        {
        }
        public CycledDynamicArray(IEnumerable<T> data) : base(data)
        {
        }

        #endregion

        public new IEnumerator<T> GetEnumerator()
        {
            return new CycledDynamicArrayEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CycledDynamicArrayEnumerator<T>(this);
        }


    }
}
