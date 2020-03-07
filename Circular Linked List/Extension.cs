using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Circular_Linked_List
{
    public static class Extensions
    {
        public static void PrintEnumerable<T>(this IEnumerable<T> item)
        {
            Console.WriteLine(String.Join("->", item));
        }
    }
}
