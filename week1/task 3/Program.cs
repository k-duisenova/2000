using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {/// <summary>
    /// making new array with doubled elements of the existing array
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
        static int[] MakeDoubleArray(int[] a)
        {
            int[] arr = new int[a.Length * 2];

            for (int i = 0; i < a.Length; i++)
            {
                arr[2 * i] = arr[2 * i + 1] = a[i]; // doubling one integer number
            }

            return arr;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // n - size of the array a
            int[] a = new int[n];
            string s = Console.ReadLine();
            a = s.Split(' ').Select(int.Parse).ToArray(); // making the array n from entered numbers

            int[] arr = new int[2 * n]; // new array with doubled size
            arr = MakeDoubleArray(a);

            for (int i = 0; i < arr.Length; ++i)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
