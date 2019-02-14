using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\UserPC\week1"); // defining the directory(folder)
            PrintInfo(dir, 0);
        }
        /// <summary>
        /// printing the content of the given folder
        /// </summary>
        /// <param name="fsi"></param>
        /// <param name="k"></param>
        static void PrintInfo(FileSystemInfo fsi, int k)
        {
            string s = new string(' ', k); 
            Console.WriteLine(s + fsi.Name); // writing the names of the content of the directory

            if (fsi.GetType() == typeof(DirectoryInfo)) 
            {
                FileSystemInfo[] arr = ((DirectoryInfo)fsi).GetFileSystemInfos(); // content of the folder = array of files
                for (int i = 0; i < arr.Length; ++i)
                {
                    PrintInfo(arr[i], k + 3); // k+3 in order to write down the content in structured way(creating spaces)
                }
            }
        }
    }
}
