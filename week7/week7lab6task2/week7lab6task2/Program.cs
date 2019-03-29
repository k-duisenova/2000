using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace week7lab6task2
{
    public class MyThread
    {
        //Thread ThreadField = new Thread();
        public MyThread(string name)
        {
            
        }
        
        public void StartThread()
        {
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyThread t1 = new MyThread("thread1");
            MyThread t2 = new MyThread("thread2");
            MyThread t3 = new MyThread("thread3");

            t1.StartThread();
            t2.StartThread();
            t3.StartThread();
        }
    }
}
