using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {/// <summary>
    /// defining whether it is palindrome or not
    /// </summary>
    /// <param name="s"></param>
    /// <param name="k"></param>
    /// <returns></returns>
        public static bool IsPalindrome(string s, int k)
        {
            for (int i = 0; i < k / 2; i++)
            {
                if (s[i] != s[k - i - 1])
                    return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C: \Users\UserPC\Desktop\1.txt.txt"); // reading the numbers from the file
            int k = text.Length; 
            if(IsPalindrome(text,k) == true)
            {
                Console.WriteLine("Yes");
     
            } else
            {
                Console.WriteLine("No");
            }
        }
    }
}
