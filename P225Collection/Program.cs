using System;
using System.Collections;
using System.Collections.Generic;

namespace P225Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Non Generic Collection
            //ArrayList arrayList = new ArrayList();
            //arrayList.Add("Test");
            //arrayList.Add(156);
            //arrayList.Add(156);

            //foreach (var item in arrayList)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("=============Before==============");
            //ArrayList arrayList1 = new ArrayList();
            //arrayList1.Add("Hello");
            //arrayList1.Add("World");

            //arrayList.InsertRange(1, arrayList1);
            ////arrayList.Remove(156);
            ////arrayList.RemoveAt(6546);


            //Console.WriteLine("============After==================");
            //foreach (var item in arrayList)
            //{
            //    Console.WriteLine(item);
            //}

            //arrayList1.AddRange(arrayList);

            //SortedList sortedList = new SortedList();
            //sortedList.Add(900, "Test - 9");
            //sortedList.Add(800, "Test - 8");
            //sortedList.Add(700, "Test - 7");
            //sortedList.Add(600, "Test - 6");

            //foreach (var item in sortedList.Keys)
            //{
            //    Console.WriteLine($"{item} {sortedList[item]}");
            //}


            //FIFO - First In First Out
            //Queue queue = new Queue();
            //queue.Enqueue("Hello");
            //queue.Enqueue(225);
            //queue.Enqueue(true);

            ////Console.WriteLine(queue.Peek());
            ////Console.WriteLine(queue.Count);

            ////Console.WriteLine("==================Befor-Deque============");
            ////queue.Dequeue();
            ////Console.WriteLine("==================After-Deque============");
            ////Console.WriteLine(queue.Peek());
            ////Console.WriteLine(queue.Count);

            //foreach (var item in queue)
            //{
            //    Console.WriteLine(item);
            //}

            //LIFO - Last In First Out
            //Stack stack = new Stack();
            //stack.Push("Test");
            //stack.Push(255);
            //stack.Push(true);

            ////Console.WriteLine(stack.Peek());
            ////Console.WriteLine(stack.Count);

            ////Console.WriteLine("==================Befor-Deque============");
            ////stack.Pop();
            ////Console.WriteLine("==================After-Deque============");
            ////Console.WriteLine(stack.Peek());
            ////Console.WriteLine(stack.Count);

            //foreach (var item in stack)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region Generic Collection
            //List<string> strList = new List<string>();

            //strList.Add("Test");
            //strList.Add("Test2");

            ////Console.WriteLine(strList[0]);
            //Console.WriteLine(strList.Count);

            Queue<string> strQue = new Queue<string>();
            strQue.Enqueue("Test");
            strQue.Peek();
            string test = strQue.Dequeue();

            Stack<int> intStack = new Stack<int>();
            intStack.Push(546);
            intStack.Peek();
            int a = intStack.Pop();

            Dictionary<string, string> phone = new Dictionary<string, string>();
            phone.Add("Hamid Mammad", "+9945555555");
            phone.Add("Test", "+89798798");

            foreach (var item in phone)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }
            #endregion
        }
    }
}
