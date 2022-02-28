using HumanResurce.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResurce.Interfaces
{
    interface IHumanResourceManager
    {
        Department[] Departments { get; }

        void AddDepartment(string name, int worketlimit, double salarylimit);
        Department[] GetDepartments();
        void EditDepartaments(string oldname, string newname);
        void AddEmployee(string departmentname, string fullname, string position, double salary);
        void RemoveEmployee(string employeeno, string departmentname);
        void EditEmployee(string employeeno, string fullname, double salary, string position);
    }
}
