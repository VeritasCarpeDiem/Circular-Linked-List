using System;

namespace Circular_Linked_List
{
    class Program
    {
        static void Main()
        {
            CircularLinkedList<int> list = new CircularLinkedList<int>();

            list.AddFirst(1);
            list.AddLast(2);
            list.AddLast(3);

            list.PrintForwards();
           //DOesnt work list.PrintEnumerable();

            Console.WriteLine(list.Count);
            list.Reverse();
            list.PrintForwards();
        }
    }
}
