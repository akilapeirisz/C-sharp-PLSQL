using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("ST001", "ALEX SMITH");
            Console.WriteLine(student.Studentid);
            Console.WriteLine(student.Name);
            student.Name = "Agent Smith";
            Console.WriteLine(student.Studentid);
            Console.WriteLine(student.Name);
            string name = "";
            for (int i = 0; i < 120; i++)
            {
                name += "a";
            }
            student.Name = name;
            Console.WriteLine(student.Studentid);
            Console.WriteLine(student.Name);
            Console.ReadKey();
        }
    }

    class Student
    {
        private string studentid;

        public string Studentid
        {
            get { return studentid; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length > 100)
                {
                    Console.WriteLine("Error: Name should be less than 100 characters.");
                }
                else
                {
                    name = value;
                }
            }
        }

        public Student(string studentid, string name)
        {
            this.studentid = studentid;
            this.name = name;
        }

    }
}
