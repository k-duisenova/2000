using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int n = int.Parse(s); //converting the line into integer number

            for (int i = 0; i < n; ++i) //cycle for rows
            {
                for (int j = 0; j <= i; ++j) //cycle for columns
                {
                    Console.Write("[*]"); 
                }
                Console.WriteLine(); //new line(row)
            }
        }
    }
}
