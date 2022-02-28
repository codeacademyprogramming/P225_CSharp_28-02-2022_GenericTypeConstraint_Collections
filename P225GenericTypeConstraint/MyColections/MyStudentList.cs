using P225GenericTypeConstraint.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P225GenericTypeConstraint.MyColections
{
    class MyStudentList
    {
        private Student[] _arr;

        public MyStudentList()
        {
            _arr = new Student[0];
        }

        public void Add(Student item)
        {
            Array.Resize(ref _arr, _arr.Length + 1);
            _arr[_arr.Length - 1] = item;
        }

        public Student ElemetAt(int index)
        {
            if (index >= 0 && index < _arr.Length)
            {
                return _arr[index];
            }

            throw new IndexOutOfRangeException("Duzgun Index Daxil Et");
        }
    }
}
