using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4TaskStudent
{
    class Student
    {
        private int studentID;
        private string studentName;
        private string studentDOB;
        private string studentEmail;
        private double studentGPA;

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter 3 Student Details\n");
            Student s1 = new Student();
            Student s2 = new Student();
            Student s3 = new Student();
            double[] details = new double[3];
            double[] studentArr = new double[3];



            Console.WriteLine("---------------Student 1 Data-----------------");
            s1.InputUser();
            studentArr[0] = s1.studentGPA;


            Console.ReadLine();

            Console.WriteLine("---------------Student 2 Data-----------------");
            s2.InputUser();
            studentArr[1] = s2.studentGPA;



            Console.ReadLine();

            Console.WriteLine("---------------Student 3 Data-----------------");
            s3.InputUser();
            studentArr[2] = s3.studentGPA;


            s1.Display(); Console.WriteLine("--------------------------------");
            s2.Display(); Console.WriteLine("--------------------------------");
            s3.Display(); Console.WriteLine("--------------------------------");

            double highestCGPA = studentArr.Max();

            if (highestCGPA == s1.studentGPA)
            {
                Console.WriteLine("CR: " + s1.studentName);
            }
            else if (highestCGPA == s2.studentGPA)
            {
                Console.WriteLine("CR: " + s2.studentName);
            }
            else if (highestCGPA == s3.studentGPA)
            {
                Console.WriteLine("CR: " + s3.studentName);
            }

            Console.ReadLine();

        }
        public double[] arr = new double[6];
        double TotalGPA;
        public double[] InputUser()
        {

            Console.Write("Enter Student ID:");
            studentID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Student Name:");
            studentName = Console.ReadLine();
            Console.Write("Enter Student DOB:");
            studentDOB = Console.ReadLine();
            Console.Write("Enter Student Email:");
            studentEmail = Console.ReadLine();

            for (int i = 1; i <= 5; i++)
            {
                Console.Write("Enter GPA for Semester {0} : ", i);
                int gpa = Convert.ToInt32(Console.ReadLine());
                TotalGPA = gpa + TotalGPA;

            }
            double CGPA = TotalGPA / 5;
            studentGPA = CGPA;
            Console.WriteLine("CGPA = " + CGPA);

            return arr;


        }


        public static double GetMaxCGPA(Student[] students)
        {
            double maxCGPA = 0;
            foreach (Student s in students)
            {
                if (s.studentGPA > maxCGPA)
                {
                    maxCGPA = s.studentGPA;
                }
            }
            return maxCGPA;
        }
        public void Display()
        {
            Console.WriteLine("Student ID     : " + studentID);
            Console.WriteLine("Student Name   : " + studentName);
            Console.WriteLine("Student DOB    : " + studentDOB);
            Console.WriteLine("Student Email  : " + studentEmail);
            Console.WriteLine("Student CGPA   : " + studentGPA);
        }
    }
}


