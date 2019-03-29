using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace week7lab6task1
{
    class Program
    {
        static void startThread()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.Write(Thread.CurrentThread.Name + " ");
            }
        }
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[5];
            for (int i = 1; i <= 4; i++)
            {
                threads[i] = new Thread(startThread);
                threads[i].Name = i.ToString();
                threads[i].Start();
            }
            

        }
       

    }
}
