using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    class Program
    {   /// <summary>
    /// defining prime numbers
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
            string numbers = System.IO.File.ReadAllText(@"C:\Users\UserPC\Desktop\1.txt.txt"); // reading the numbers from the file
            int[] a = new int[numbers.Length/2]; // divided by 2 because the line contains spaces
            a = numbers.Split(' ').Select(int.Parse).ToArray();
            List<int> list = new List<int>(); // creating list to store prime numbers
            for (int i = 0; i < a.Length; ++i)
            {
                if (IsPrime(a[i]) == true)
                {
                    list.Add(a[i]); // adding prime numbers to the list
                    
                }
            }
 
            var result = String.Join(" ", list.ToArray()); // converting the list into string
            System.IO.File.WriteAllText(@"C:\Users\UserPC\Desktop\2.txt", result); // writing prime numbers to the new file

        }
    }
}
