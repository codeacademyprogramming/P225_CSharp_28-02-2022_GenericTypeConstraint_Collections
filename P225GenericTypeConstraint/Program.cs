using System;
using P225GenericTypeConstraint.Models;
using P225GenericTypeConstraint.MyColections;

namespace P225GenericTypeConstraint
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyStringList myStringList = new MyStringList();

            //myStringList.Add("Ismayil");
            //myStringList.Add("Tural");
            //myStringList.Add("Vusal");
            //myStringList.Add("Onur");

            //Console.WriteLine(myStringList.ElemetAt(546));

            //MyList<string> myStringList = new MyList<string>();
            //myStringList.Add("Ismayil");
            //myStringList.Add("Tural");
            //myStringList.Add("Vusal");
            //myStringList.Add("Onur");

            //try
            //{
            //    Console.WriteLine(myStringList.ElemetAt(545));
            //}
            //catch (IndexOutOfRangeException)
            //{

            //    Console.WriteLine("Duzgun Index Daxil Et");
            //}

            //MyList<int> myIntList = new MyList<int>();
            //myIntList.Add(5);
            //myIntList.Add(15);
            //myIntList.Add(35);
            //myIntList.Add(55);

            //Console.WriteLine($"{myIntList.ElemetAt(3)} {myStringList.ElemetAt(3)} {myIntList.Length}");

            //foreach (var item in myIntList.GetArr())
            //{
            //    Console.WriteLine(item);
            //}

            //MyList<Student> mySudentList = new MyList<Student>();
            //mySudentList.Add(new Student { Name = "Abdulla", SurName = "Rehimli", Age = 27 });
            //mySudentList.Add(new Student { Name = "Ishaq", SurName = "Yaqublu", Age = 22 });
            //mySudentList.Add(new Student { Name = "Eltac", SurName = "MelikMemmedov", Age = 21 });

            //Console.WriteLine($"{mySudentList.ElemetAt(2).Name} {mySudentList.ElemetAt(2).SurName} {mySudentList.ElemetAt(2)}");

            //MyList<Student,Human> myHumanist = new MyList<Student,Human>();


            //MyList<Human,object> myHumanist1 = new MyList<Human,object>();


            //String str = new String("");
            //WriteConsole<string, object>("Test");
            //WriteConsole<int>();

            MyList<string> myList = new MyList<string>();
            myList.Add("Test1");
            myList.Add("Test2");
            myList.Add("Test3");
            myList.Add("Test4");

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }

        //static void WriteConsole<T,U>(T item) where T : U
        //{
        //    Console.WriteLine(item);
        //}

        //static void WriteConsole(int item)
        //{
        //    Console.WriteLine(item);
        //}
    }
}
