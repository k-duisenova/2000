using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "test1.txt";
          
            string sourcePath = @"C:\Users\UserPC\Documents\path";
            string targetPath = @"C:\Users\UserPC\Documents\path1";

            // Use Path class to manipulate file and directory paths
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            if (!System.IO.File.Exists(sourceFile))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(sourceFile))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
            }
            
            // Creating a target folder
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            // Copying a file to another location
            System.IO.File.Copy(sourceFile, destFile, true);

           

            if (System.IO.File.Exists(@"C:\Users\UserPC\Documents\path\test1.txt"))
            {
                // Use a try block to catch IOExceptions, to handle the case of the file already being
                // opened by another process.
                try
                {
                    System.IO.File.Delete(@"C:\Users\UserPC\Documents\path\test1.txt");
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            // Keep console window open in debug mode
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
