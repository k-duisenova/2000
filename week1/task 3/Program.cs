using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // n - size of the array a
            int[] a = new int[n];
            string s = Console.ReadLine();
            a = s.Split(' ').Select(int.Parse).ToArray(); // making the array n from entered numbers
            for (int i = 0; i < a.Length; ++i)
            {
                Console.Write(a[i] + " ");
                Console.Write(a[i] + " "); // doubling the number
            }
        }
    }
}
