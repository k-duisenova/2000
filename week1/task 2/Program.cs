using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Student
    {
        string name;
        string id;
        int YearOfStudy;
        public Student(string n, string i)
        {
            name = n;
            id = i;
 
        }
        public void PrintInfo()
        {
            YearOfStudy = int.Parse(Console.ReadLine());
            Console.WriteLine("NAME:" + name + " " + "ID:" + id + " " + "Year of study:" + (YearOfStudy+1));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("Duisenova Kuralay", "18BD110770");
            s.PrintInfo();
        }
    }
}
