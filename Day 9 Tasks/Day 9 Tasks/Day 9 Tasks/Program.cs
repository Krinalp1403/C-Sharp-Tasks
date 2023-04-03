using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day_9_Tasks
{

    public static class MyExtensions
    {
        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            // Define a regular expression pattern for email validation
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Create a regular expression object and match the email address
            var regex = new Regex(pattern);
            var match = regex.Match(email);

            return match.Success;
        }


        public static bool IsValidPhoneNumber(this long number)
        {
            return number.ToString().Length <= 10;
        }

       
    }
    public class Program
    {



        static List<Student> students= new List<Student>();

        static void Main(string[] args)
        {
            while (true)

            {
                Console.WriteLine("\n-------------- Admission Management System ---------------");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Get Student by ID");
                Console.WriteLine("4. Delete Student by ID");


                Console.WriteLine("0. Exit");
                Console.Write("Please Enter your choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        break;
                    case 0:
                        Environment.Exit(0);// exit
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        public enum Gender
        {
            Male,
            Female
        }

        public class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string FullName { get; set; }
            public Gender Gender { get; set; }
            public string Email { get; set; }
            public long PhoneNumber { get; set; }
            public string Address { get; set; }

        }


        static void AddStudent()
        {


            try
            {
                Student s1 = new Student();
                //employees

                Console.Write("First Name (Required): ");
                s1.FirstName = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(s1.FirstName))
                {
                    Console.WriteLine("First Name is Required!");
                    Console.ReadKey();

                    return;
                }

                Console.Write("Last Name (Required): ");
                s1.LastName = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(s1.LastName))
                {
                    Console.WriteLine("Last Name is Required!");
                    Console.ReadKey();

                    return;
                }
                Console.WriteLine("Full Name : "+ s1.FirstName + s1.LastName);

                Console.Write("Please enter your gender (Male/Female): ");
                string genderString = Console.ReadLine();
                Gender gender;

                if (!Enum.TryParse<Gender>(genderString, out gender))
                {
                    Console.WriteLine("Invalid gender input. Please try again.");
                    return;
                }


                Console.Write("Email Address (Required, Must be Valid): ");
                s1.Email = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(s1.Email) || !s1.Email.IsValidEmail())
                {
                    Console.WriteLine("Invalid Email Address!");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Phone Number (Required, only int, Range Max 10 numbers): ");
                long phoneNumber;
                if (!long.TryParse(Console.ReadLine().Trim(), out phoneNumber) || !phoneNumber.IsValidPhoneNumber())
                {
                    Console.WriteLine("Invalid Phone Number!");
                    Console.ReadKey();

                    return;
                }
                s1.PhoneNumber = phoneNumber;

                Console.Write("Address : ");
                string Address = Console.ReadLine().Trim();
          
                    Console.ReadKey();

                
                

           

                Console.WriteLine("All Fields are Validated..");

                Student.Add(s1);

                SaveEmployeesToJson();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DisplayAllEmployees()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees added yet.");
                return;
            }

            foreach (Employee emp in employees)
            {
                Console.WriteLine($"Name: {emp.FirstName} {emp.LastName}");
                Console.WriteLine($"Gender: {emp.Gender}");
                Console.WriteLine($"Email: {emp.Email}");
                Console.WriteLine($"Phone Number: {emp.PhoneNumber}");
                Console.WriteLine($"Designation: {emp.Designation}");
                Console.WriteLine($"Salary: {emp.Salary}");
                Console.WriteLine("--------------------------");
            }
        }
        static void SaveEmployeesToJson()
        {
            string fileName = @"D:\C# Krinal Patel\Day 8 Tasks\Files\KPJSON1.json";
            string json = JsonConvert.SerializeObject(employees, Formatting.Indented);

            File.AppendAllText(fileName, json);
            Console.WriteLine("Employee data saved to KPJSON1.JSON file.");
        }
    }

}
