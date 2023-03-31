using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace EmployeeRecord
{
    class Program
    {
        static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            while (true)

            {
                Console.WriteLine("\n-------------- Employee Management System ---------------");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Display All Employees");
                Console.WriteLine("0. Exit");
                Console.Write("Please Enter your choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());
             

                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        SaveEmployeesToJson();

                        break;
                    case 2:
                        DisplayAllEmployees();
                        break;
                    case 3:
                        Console.WriteLine("Exiting...");
                        return;

                    case 0:
                        Environment.Exit(1);// exit
                        break; 
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        class Employee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
            public string Email { get; set; }
            public long PhoneNumber { get; set; }
            public Designation Designation { get; set; }
            public double Salary { get; set; }
        }
        static void AddEmployee()
        {
            try
            {
                Employee emp = new Employee();
                //employees

                Console.Write("First Name (Required): ");
                emp.FirstName = Console.ReadLine();

                Console.Write("Last Name (Required): ");
                emp.LastName = Console.ReadLine();

                Console.Write("Gender (Required): ");
                emp.Gender = Console.ReadLine();

                Console.Write("Email Address (Required, Must be Valid): ");
                emp.Email = Console.ReadLine();

                Console.Write("Phone Number (Required, only int, Range Max 10 numbers): ");
                emp.PhoneNumber = Convert.ToInt64(Console.ReadLine());

                Console.Write("Designation (Required, Should be from Enum, Developer, QA): ");
                if (!Enum.TryParse(Console.ReadLine(), out Designation desig))
                {
                    Console.WriteLine("Designation is Required and Should be from Enum, Developer, QA!");
                    return;
                }
                emp.Designation = desig;

                Console.Write("Salary (Required, Min 10,000 & Max 50,000): ");
                emp.Salary = Convert.ToDouble(Console.ReadLine());

                employees.Add(emp);

                Console.WriteLine("Employee added successfully.");
            
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

            //Console.WriteLine("Reading from the file..");
            //string jsonDataFromFile = File.ReadAllText(fileName);


            //Person p3 = JsonConvert.DeserializeObject<Person>(jsonDataFromFile);

            //Console.WriteLine("Name : " + p3.Name);
            //Console.WriteLine("Age : " + p3.Age);
            //Console.WriteLine(p3.City);

            string json = JsonConvert.SerializeObject(employees, Formatting.Indented);
            File.AppendAllText(fileName, json);
            Console.WriteLine("Employee data saved to KPJSON1.JSON file.");
        }


        //static void SaveEmployeesToJson()
        //{
        //    string fileName = @"D:\C# Krinal Patel\Day 8 Tasks\Files\KPJSON1.json";
        //    List<Employee> existingEmployees = new List<Employee>();

        //    // Read the existing JSON data from the file
        //    if (File.Exists(fileName))
        //    {
        //        string jsonDataFromFile = File.ReadAllText(fileName);
        //        existingEmployees = JsonConvert.DeserializeObject<List<Employee>>(jsonDataFromFile);
        //    }

        //    // Add the new employee to the list
        //    Employee newEmployee = CreateEmployee();
        //    existingEmployees.Add(newEmployee);

        //    // Serialize the entire list of employees to JSON
        //    string json = JsonConvert.SerializeObject(existingEmployees, Formatting.Indented);

        //    // Write the JSON data back to the file
        //    File.WriteAllText(fileName, json);
        //    Console.WriteLine("Employee data saved to KPJSON1.JSON file.");
        //}



        enum Designation
        {
            Developer,
            QA
        }
    }


}
