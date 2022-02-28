using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResurce.Models
{
    class Employee
    {
        private static int _count=1000;
        public string No { get; set; }
        public string FullName { get; set; }
        private string _position;
        public string Position
        {
            get => _position;
            set
            {
                while (!CheckPosition(value))
                {
                    Console.WriteLine("Duzgun Vezife Adi Daxil Et:");
                    value = Console.ReadLine();
                }
                _position = value;
            }
        }
        private double _salary;
        public double Salary 
        {
            get => _salary;
            set
            {
                while (value < 250)
                {
                    Console.WriteLine("Duzgun Maas Daxil Edin:");
                    double.TryParse(Console.ReadLine(), out value);
                }
                _salary = value;
            }
        }
        public string DepartmentName { get; set; }

        public Employee(string fullname, string position, double salary, string departmentname)
        {

            FullName = fullname;
            Position = position;
            Salary = salary;
            DepartmentName = departmentname;
            _count++;
            No = $"{DepartmentName.Substring(0, 2).ToUpper()}{_count}";
        }

        private bool CheckPosition(string position)
        {
            if (position.Length >= 2)
            {
                foreach (char item in position)
                {
                    if (!char.IsLetter(item))
                        return false;
                }
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Iscinin Nomresi: {No}\nIscinin Adi Soyado: {FullName}\nIscinin Vezifesi: {_position}\nIscinin Maasi: {_salary}\n Iscinin Departamenti: {DepartmentName}";
        }
    }
}