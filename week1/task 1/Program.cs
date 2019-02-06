using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {/// <summary>
    /// the function to find prime numbers from the array
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
        public static bool IsPrime(int x)
        {
            if (x <= 1) // by definition of prime numbers: they have to be more than 1
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(x); ++i)
            {
                if (x % i == 0) //by definition prime numbers can be divided by 1 and themselves only
                {
                    return false;
                }
            }
            return true; // if two conditions above are not hold, it is prime number
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //n - size of the array
            int[] a = new int[n];

            string s = Console.ReadLine(); // reading the elements of an array
            a = s.Split(' ').Select(int.Parse).ToArray(); // splitting the string to create an array from previously entered integer numbers

            int cnt = 0;

            for (int i = 0; i < n; ++i)
            {
                if (IsPrime(a[i]) == true)
                {
                    cnt++;
                }
            }
            Console.WriteLine(cnt); // outputting the total number of prime numbers 
            for (int i = 0; i < a.Length; ++i)
            {
                if (IsPrime(a[i]) == true)
                {
                    Console.Write(a[i] + " "); // output: all prime numbers from the arrayii
                }
            }
        }
    }
}
