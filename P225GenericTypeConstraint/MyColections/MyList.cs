using P225GenericTypeConstraint.Interfaces;
using P225GenericTypeConstraint.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P225GenericTypeConstraint.MyColections
{
    class MyList<T> : IEnumerable /*where T : A*/
    {
        private T[] _arr;

        public int Length => _arr.Length;

        public MyList()
        {
            _arr = new T[0];
        }

        public void Add(T item)
        {
            Array.Resize(ref _arr, _arr.Length + 1);
            _arr[_arr.Length - 1] = item;
        }

        public T[] GetArr()
        {
            return _arr;
        }

        public T ElemetAt(int index)
        {
            if (index >= 0 && index < _arr.Length)
            {
                return _arr[index];
            }

            throw new IndexOutOfRangeException("Duzgun Index Daxil Et");
        }

        public IEnumerator GetEnumerator()
        {
            return _arr.GetEnumerator();
        }
    }
}
