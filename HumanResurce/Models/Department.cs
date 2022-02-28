using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResurce.Models
{
    class Department
    {
        public string Name { get; set; }
        private int _workerLimit;
        public int WorkerLimit 
        {
            get => _workerLimit;
            set
            {
                while (value < 1)
                {
                    Console.WriteLine("Duzgun Isci Limiti Daxil Edin:");
                    int.TryParse(Console.ReadLine(), out value);
                }
                _workerLimit = value;
            }
        }
        private double _salaryLimit;
        public double SalaryLimit 
        {
            get => _salaryLimit;
            set
            {
                while (value < (_workerLimit * 250))
                {
                    Console.WriteLine("Duzgun Maas Limiti Daxil Edin:");
                    double.TryParse(Console.ReadLine(), out value);
                }
                _salaryLimit = value;
            }
        }
        public Employee[] Employees;
        public Department(string name, int workerlimit, double salarylimit)
        {
            Name = name.ToUpper();
            WorkerLimit = workerlimit;
            SalaryLimit = salarylimit;
            Employees = new Employee[0];
        }
        public double CalcSalaryAverage()
        {
            double sum = 0;
            int count = 0;

            foreach (Employee employee in Employees)
            {
                if (employee != null)
                {
                    sum += employee.Salary;
                    count++;
                }
            }

            return sum > 0 ? sum / count : 0;
        }

        public override string ToString()
        {
            return $"Departamentin Adi: {Name}\nDepartamentin Isci Limiti: {_workerLimit}\nDepartamentin Maas Limiti: {_salaryLimit}";
        }
    }
}
