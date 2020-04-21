

namespace MyListTemplate
{
    using System;
using System.Collections;
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();
            list.Add(9);
            list.Add(8);
            list.Add(7);
            list.Add(6);
            list.Add(5);
            list.Add(4);
            PrintList(list);
            System.Console.WriteLine($"8 index is {list.IndexOf(8)}");
            System.Console.WriteLine("Add 144 index 2");
            list.Insert(2,144);
            PrintList(list);
            System.Console.WriteLine("Remove value 5");
            list.Remove(5);
            PrintList(list);
            System.Console.WriteLine("Remove element index 4");
            list.RemoveAt(4);
            PrintList(list);
            Console.ReadKey();
        }

        static void PrintList<T>(MyList<T> list)
        {
            foreach (var item in list)
            {
                System.Console.WriteLine($"Element {item}");
            }
        }
    }
}
