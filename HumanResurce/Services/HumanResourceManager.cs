using HumanResurce.Interfaces;
using HumanResurce.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResurce.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        private Department[] _departments;
        public Department[] Departments => _departments;

        public HumanResourceManager()
        {
            _departments = new Department[0];
        }

        public void AddDepartment(string name, int worketlimit, double salarylimit)
        {
            foreach (Department department in _departments)
            {
                if (department != null && department.Name.ToLower() == name.ToLower())
                {
                    Console.WriteLine("Daxil Edilen Adaa Department Artiq Movcuddur");
                    return;
                }
            }

            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length - 1] = new Department(name.Trim(), worketlimit, salarylimit);
        }

        public void AddEmployee(string departmentname, string fullname, string position, double salary)
        {
            Department existedDepartment = null;

            foreach (Department department in _departments)
            {
                if (department != null && department.Name.ToLower() == departmentname.Trim().ToLower())
                {
                    existedDepartment = department;
                    break;
                }
            }

            if (existedDepartment != null)
            {
                int employeeCount = 0;
                foreach (Employee employee in existedDepartment.Employees)
                {
                    if (employee != null)
                    {
                        employeeCount++;
                    }
                }

                if (employeeCount < existedDepartment.WorkerLimit)
                {
                    if (((existedDepartment.CalcSalaryAverage() * employeeCount)+salary) <= existedDepartment.SalaryLimit)
                    {
                        Array.Resize(ref existedDepartment.Employees, existedDepartment.Employees.Length + 1);
                        existedDepartment.Employees[existedDepartment.Employees.Length - 1] = new Employee(fullname.Trim(), position.Trim(), salary, existedDepartment.Name);
                        Console.WriteLine("Isci Ugutla Elave Edildi");
                        return;
                    }
                    Console.WriteLine("Maas Limiti Asir");
                    return;
                }
                Console.WriteLine("Isci Limiti Asir");
                return;
            }
            Console.WriteLine("Daxil Edilen Adaa Departament Tapilmadi");
        }

        public void EditDepartaments(string oldname, string newname)
        {
            Department existedDepartment = null;

            foreach (Department department in _departments)
            {
                if (department != null && department.Name.ToLower() == oldname.Trim().ToLower())
                {
                    existedDepartment = department;
                    break;
                }
            }

            if (existedDepartment != null)
            {
                foreach (Department department in _departments)
                {
                    if (department != null && department.Name.ToLower() == newname.Trim().ToLower())
                    {
                        Console.WriteLine("Daxil Edilen Yeni Departament Adi Artiq Movcuddur");
                        return;
                    }
                }

                existedDepartment.Name = newname.ToUpper().Trim();

                foreach (Employee employee in existedDepartment.Employees)
                {
                    if (employee != null)
                    {
                        employee.DepartmentName = existedDepartment.Name;
                        employee.No = employee.No.Replace(employee.No.Substring(0, 2), existedDepartment.Name.Substring(0, 2));
                    }
                }
                return;
            }
            Console.WriteLine("Daxil Edilen Adda Departament Tapilmadi");
        }

        public void EditEmployee(string employeeno, string fullname, double salary, string position)
        {
            Department existedDepartment = null;
            Employee existedEmployee = null;

            foreach (Department department in _departments)
            {
                bool check = false;

                if (department != null)
                {
                    foreach (Employee employee in department.Employees)
                    {
                        if (employee != null && employee.No.ToLower() == employeeno.Trim().ToLower() && employee.FullName.ToLower() == fullname.Trim().ToLower())
                        {
                            existedEmployee = employee;
                            existedDepartment = department;
                            check = true;
                            break;
                        }
                    }

                    if (check)
                    {
                        break;
                    }
                }
            }

            if (existedEmployee != null)
            {
                int employeeCount = 0;
                foreach (Employee employee in existedDepartment.Employees)
                {
                    if (employee != null)
                    {
                        employeeCount++;
                    }
                }
                double oldSalary = existedEmployee.Salary;
                existedEmployee.Position = position.Trim();
                existedEmployee.Salary = salary;

                if ((((existedDepartment.CalcSalaryAverage() * employeeCount)-existedEmployee.Salary)+salary)> existedDepartment.SalaryLimit)
                {
                    existedEmployee.Salary = oldSalary;
                    Console.WriteLine("Daxil Edilen Yeni Maas Limiti Asir");
                    return;
                }
            }
            Console.WriteLine("Daxil Edilen Nomreli Isci Tapilmadi");
        }

        public Department[] GetDepartments()
        {
            Department[] existedDepartments = new Department[0];

            foreach (Department department in _departments)
            {
                if (department != null)
                {
                    Array.Resize(ref existedDepartments, existedDepartments.Length + 1);
                    existedDepartments[existedDepartments.Length - 1] = department;
                }
            }

            return existedDepartments;
        }

        public void RemoveEmployee(string employeeno, string departmentname)
        {
            foreach (Department department in _departments)
            {
                if (department != null && department.Name.ToLower() == departmentname.Trim().ToLower())
                {
                    for (int i = 0; i < department.Employees.Length; i++)
                    {
                        if (department.Employees[i] != null && department.Employees[i].No.ToLower() == employeeno.Trim().ToLower())
                        {
                            department.Employees[i] = null;
                            return;
                        }
                    }
                }
            }

            Console.WriteLine("Daxil Edilen Nomreli Isci Tapilmadi");
        }
    }
}
