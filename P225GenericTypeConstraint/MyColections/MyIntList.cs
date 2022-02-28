using System;
using System.Collections.Generic;
using System.Text;

namespace P225GenericTypeConstraint.MyColections
{
    class MyIntList
    {
        private int[] _arr;

        public MyIntList()
        {
            _arr = new int[0];
        }

        public void Add(int item)
        {
            Array.Resize(ref _arr, _arr.Length + 1);
            _arr[_arr.Length - 1] = item;
        }

        public int ElemetAt(int index)
        {
            if (index >= 0 && index < _arr.Length)
            {
                return _arr[index];
            }

            throw new IndexOutOfRangeException("Duzgun Index Daxil Et");
        }
    }
}
