using System;
using System.Collections.Generic;
using System.Text;

namespace P225GenericTypeConstraint.MyColections
{
    class MyStringList
    {
        private string[] _arr;

        public MyStringList()
        {
            _arr = new string[0];
        }

        public void Add(string item)
        {
            Array.Resize(ref _arr, _arr.Length + 1);
            _arr[_arr.Length - 1] = item;
        }

        public string ElemetAt(int index)
        {
            if (index >= 0 && index < _arr.Length)
            {
                return _arr[index];
            }

            throw new IndexOutOfRangeException("Duzgun Index Daxil Et");
        }
    }
}
