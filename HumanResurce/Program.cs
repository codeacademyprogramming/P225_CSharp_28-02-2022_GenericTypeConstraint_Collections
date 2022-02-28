using HumanResurce.Models;
using HumanResurce.Services;
using System;

namespace HumanResurce
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager humanResourceManager = new HumanResourceManager();

            do
            {
                Console.WriteLine("1. Sistemdeki Butun Departamenleri Siyahisi:");
                Console.WriteLine("2. Yeni Departament Elave Et:");
                Console.WriteLine("3. Departament Uzerinde Deyisiklik Etmek:");
                Console.WriteLine("4. Sistemdeki Butun Iscilerin Siyahisi");
                Console.WriteLine("5. Departament Daxilindeki Butun Iscilerin Siyahisi:");
                Console.WriteLine("6. Yeni Isci Elave Etmek:");
                Console.WriteLine("7. Isci Uzerinde Deyisiklik Etmek:");
                Console.WriteLine("8. Departamentde Iscini Silmek:");
                Console.WriteLine("9. Sistemden Cixmaq:");

                string choose = Console.ReadLine();
                int chooseNum;

                while (!int.TryParse(choose, out chooseNum) || chooseNum < 1 || chooseNum > 9)
                {
                    Console.WriteLine("Duzgun Secim Edin:");
                    choose = Console.ReadLine();
                }

                switch (chooseNum)
                {
                    case 1:
                        ShowAllDepartment(ref humanResourceManager);
                        break;
                    case 2:
                        AddDepartment(ref humanResourceManager);
                        break;
                    case 3:
                        EditDepartment(ref humanResourceManager);
                        break;
                    case 4:
                        ShowAllEmployee(ref humanResourceManager);
                        break;
                    case 5:
                        ShowAllEmployeeByDepartmentName(ref humanResourceManager);
                        break;
                    case 6:
                        AddEmployee(ref humanResourceManager);
                        break;
                    case 7:
                        EditEmployee(ref humanResourceManager);
                        break;
                    case 8:
                        RemoveEmployee(ref humanResourceManager);
                        break;
                    case 9:
                        return;
                }

            } while (true);
        }

        static void ShowAllDepartment(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.GetDepartments().Length > 0)
            {
                foreach (Department department in humanResourceManager.GetDepartments())
                {
                    Console.WriteLine(department);
                }
                return;
            }
            Console.WriteLine("Once Siteme Departament Elave Et:");
        }

        static void AddDepartment(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Departamentin Adini Daxil Et");
            string name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Duzgun Departament Adi Daxil Et");
                name = Console.ReadLine();
            }

            Console.WriteLine("Departamentin Isci Limitini Daxil Et");
            string strworkerlimit = Console.ReadLine();
            int workerlimit;

            while (!int.TryParse(strworkerlimit, out workerlimit))
            {
                Console.WriteLine("Duzgun Isci Limiti Daxil Et");
                strworkerlimit = Console.ReadLine();
            }

            Console.WriteLine("Departamentin Maas Limitini Daxil Et:");
            string strsalarylimit = Console.ReadLine();
            double salarylimit;

            while (!double.TryParse(strsalarylimit, out salarylimit))
            {
                Console.WriteLine("Duzgun Maas Limiti Daxil Et");
                strsalarylimit = Console.ReadLine();
            }

            humanResourceManager.AddDepartment(name, workerlimit, salarylimit);
        }

        static void EditDepartment(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.GetDepartments().Length <= 0)
            {
                Console.WriteLine("Once Sisteme Departament Elave Et:");
                return;
            }

            Console.WriteLine("Sistemdeki Departamentler:");
            foreach (Department department in humanResourceManager.GetDepartments())
            {
                Console.WriteLine(department);
            }

            Console.WriteLine("Deyisiklik Etmek Isdediyin departamentin Adini Daxil Et:");
            string oldname = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(oldname))
            {
                Console.WriteLine("Duzgun Ad Daxil Et");
                oldname = Console.ReadLine();
            }

            Console.WriteLine("Departamentin Yeni Adini Daxil Et");
            string newname = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(newname))
            {
                Console.WriteLine("Duzgun Yeni Ad Daxil Et");
                newname = Console.ReadLine();
            }

            humanResourceManager.EditDepartaments(oldname, newname);
        }

        static void ShowAllEmployee(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.GetDepartments().Length < 0)
            {
                Console.WriteLine("Once Sisteme Departament Elave Et:");
                return;
            }

            int employeeCount = 0;

            foreach (Department department in humanResourceManager.GetDepartments())
            {
                foreach (Employee employee in department.Employees)
                {
                    if (employee != null)
                    {
                        Console.WriteLine(employee);
                        employeeCount++;
                    }
                }
            }

            if (employeeCount==0)
            {
                Console.WriteLine("Once Sisteme Isci Elave Edin:");
            }
        }

        static void ShowAllEmployeeByDepartmentName(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.GetDepartments().Length <= 0)
            {
                Console.WriteLine("Once Sisteme Departament Elave Et:");
                return;
            }

            Console.WriteLine("Sistemdeki Departamentler:");
            foreach (Department department in humanResourceManager.GetDepartments())
            {
                Console.WriteLine(department);
            }

            Console.WriteLine("Iscilernin Siyahisini Gormek Isdediyniz Departamentin Adini Daxil Et");
            string departmentname = Console.ReadLine();
            bool checkdepartment = true;
            bool checkemployee = true;
            while (checkdepartment)
            {
                foreach (Department department in humanResourceManager.GetDepartments())
                {
                    if (department.Name.ToLower() == departmentname.ToLower().Trim())
                    {
                        checkdepartment = false;

                        foreach (Employee employee in department.Employees)
                        {
                            if (employee != null)
                            {
                                checkemployee = false;
                                Console.WriteLine(employee);
                            }
                        }

                        if (checkemployee)
                        {
                            Console.WriteLine("Once Departamente Isci Elave Et:");
                            return;
                        }
                    }
                }

                if (checkdepartment)
                {
                    Console.WriteLine("Daxil Etdiyniz Adda Departament Tapilmadi: Duzgun Ad Daxil Edin:");
                    departmentname = Console.ReadLine();
                }
            }
        }

        static void AddEmployee(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.GetDepartments().Length <= 0)
            {
                Console.WriteLine("Once Sisteme Departament Elave Et:");
                return;
            }

            Console.WriteLine("Sistemdeki Departamentler:");
            foreach (Department department in humanResourceManager.GetDepartments())
            {
                Console.WriteLine(department);
            }

            Console.WriteLine("Isci Elave Etmek Isdediyniz Departamentin Adini Daxil Et");
            string departmentname = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(departmentname))
            {
                Console.WriteLine("Duzgun Ad Daxil edin:");
                departmentname = Console.ReadLine();
            }

            Console.WriteLine("Iscinin Adini Soyadini Daxil Et:");
            string fullname = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(fullname))
            {
                Console.WriteLine("Duzgun Ad Soyad Daxil Et:");
                fullname = Console.ReadLine();
            }

            Console.WriteLine("Iscinin Vezifesini Daxil Et:");
            string position = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(position))
            {
                Console.WriteLine("Duzgun Vezife Daxil Et");
                position = Console.ReadLine();
            }

            Console.WriteLine("Iscinin Maasini Daxil Edin:");
            string strsalary = Console.ReadLine();
            double salary;
            while (!double.TryParse(strsalary, out salary))
            {
                Console.WriteLine("Duzgun Maas Daxil Et");
                strsalary = Console.ReadLine();
            }

            humanResourceManager.AddEmployee(departmentname, fullname, position, salary);
        }

        static void EditEmployee(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.GetDepartments().Length <= 0)
            {
                Console.WriteLine("Once Sisteme Departament Elave Et:");
                return;
            }

            Console.WriteLine("Sistemdeki Departamentler:");
            foreach (Department department in humanResourceManager.GetDepartments())
            {
                Console.WriteLine(department);
            }

            Console.WriteLine("Iscilernin Siyahisini Gormek Isdediyniz Departamentin Adini Daxil Et");
            string departmentname = Console.ReadLine();
            bool checkdepartment = true;
            bool checkemployee = true;
            while (checkdepartment)
            {
                foreach (Department department in humanResourceManager.GetDepartments())
                {
                    if (department.Name.ToLower() == departmentname.ToLower().Trim())
                    {
                        checkdepartment = false;

                        foreach (Employee employee in department.Employees)
                        {
                            if (employee != null)
                            {
                                checkemployee = false;
                                Console.WriteLine(employee);
                            }
                        }

                        if (checkemployee)
                        {
                            Console.WriteLine("Once Departamente Isci Elave Et:");
                            return;
                        }
                    }
                }

                if (checkdepartment)
                {
                    Console.WriteLine("Daxil Etdiyniz Adda Departament Tapilmadi: Duzgun Ad Daxil Edin:");
                    departmentname = Console.ReadLine();
                }
            }

            Console.WriteLine("Deyisiklik Etmek Isdediyniz Iscinin Nomresini Daxil Et");
            string employeeno = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(employeeno))
            {
                Console.WriteLine("Duzgun Isci Nomresi Daxil Et:");
                employeeno = Console.ReadLine();
            }

            Console.WriteLine("Deyisiklik Etmek Isdediyniz Iscinin Tam Adini Daxil Et");
            string fullname = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(fullname))
            {
                Console.WriteLine("Duzgun Tam Ad Daxil Et:");
                fullname = Console.ReadLine();
            }

            Console.WriteLine("Iscinin Yeni Vezifesini Daxil Et");
            string position = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(position))
            {
                Console.WriteLine("Duzgun Vezife Daxil Et:");
                position = Console.ReadLine();
            }

            Console.WriteLine("Iscinin Yeni Maasini Daxil Et:");
            string strsalary = Console.ReadLine();
            double salary;

            while (!double.TryParse(strsalary, out salary))
            {
                Console.WriteLine("Duzgun Maas Daxil Et:");
                strsalary = Console.ReadLine();
            }

            humanResourceManager.EditEmployee(employeeno, fullname, salary, position);
        }

        static void RemoveEmployee(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.GetDepartments().Length <= 0)
            {
                Console.WriteLine("Once Sisteme Departament Elave Et:");
                return;
            }

            Console.WriteLine("Sistemdeki Departamentler:");
            foreach (Department department in humanResourceManager.GetDepartments())
            {
                Console.WriteLine(department);
            }

            Console.WriteLine("Iscilernin Siyahisini Gormek Isdediyniz Departamentin Adini Daxil Et");
            string departmentname = Console.ReadLine();
            bool checkdepartment = true;
            bool checkemployee = true;
            while (checkdepartment)
            {
                foreach (Department department in humanResourceManager.GetDepartments())
                {
                    if (department.Name.ToLower() == departmentname.ToLower().Trim())
                    {
                        checkdepartment = false;

                        foreach (Employee employee in department.Employees)
                        {
                            if (employee != null)
                            {
                                checkemployee = false;
                                Console.WriteLine(employee);
                            }
                        }

                        if (checkemployee)
                        {
                            Console.WriteLine("Once Departamente Isci Elave Et:");
                            return;
                        }
                    }
                }

                if (checkdepartment)
                {
                    Console.WriteLine("Daxil Etdiyniz Adda Departament Tapilmadi: Duzgun Ad Daxil Edin:");
                    departmentname = Console.ReadLine();
                }
            }

            Console.WriteLine("Silmek Isdediyniz Iscinin Nomresini Daxil Et");
            string employeeno = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(employeeno))
            {
                Console.WriteLine("Duzgun Isci Nomresi Daxil Et:");
                employeeno = Console.ReadLine();
            }

            humanResourceManager.RemoveEmployee(employeeno, departmentname);
        }
    }
}
