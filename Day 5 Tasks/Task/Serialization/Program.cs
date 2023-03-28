using InheritanceTask1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace InheritanceTask1
{
    public class Person
    {

        public string name;
        public int age;
        public string city;


        public void Display()
        {
            Console.WriteLine("-------------- This is Person Class ------------");
            try
            {
                Console.Write("Enter Name : ");
                name = Convert.ToString(Console.ReadLine());
                Console.Write("Enter Age : ");
                age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter City : ");
                city = Convert.ToString(Console.ReadLine());
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public void ToStrings()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"City: {city}");
        }
    }
    public class City : Person
    {
        public double population;
        public void getName()
        {
            Console.WriteLine("-------------- This is City Class ------------");
            try
            {
                Console.Write("Enter Population : ");
                population = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("City Name  : " + city);
                Console.WriteLine("Population : " + population);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
      
    }
   
    public class Program
    {

        static void Main(string[] args)
        {

            City c1 = new City();

            Console.WriteLine("--------------- Inheritance Implementation ----------------");

            c1.Display();

            c1.getName();
            Console.WriteLine("--------------- People Class Data ---------------");

            Person p1 = new Person();
            p1.Display();

            Console.WriteLine("--------------- Person class Data ----------------");

            p1.ToStrings();

            Console.WriteLine("Press Enter for JSON Serialization");
            Console.ReadLine();
            Console.WriteLine("--------------- Serialization Implementation ----------------");


            string jsonData = JsonConvert.SerializeObject(p1);
            Console.WriteLine("--------------- JSON Serialize ----------------");
            Console.WriteLine(jsonData);

            string fileName1 = @"D:\C# Training\Day 5 Tasks\Files\KPJSON1.json";

            if (File.Exists(fileName1))
            {
                File.Delete(fileName1);
            }

            using (StreamWriter sw = File.CreateText(fileName1))
            {
                sw.WriteLine(jsonData);
            }
            Console.WriteLine("JSON File is serialized successfully..!!");

            Person p2 = JsonConvert.DeserializeObject<Person>(jsonData);
            Console.WriteLine("--------------- JSON Deserialize ----------------");

            Console.WriteLine("Reading from the file..");
            string jsonDataFromFile = File.ReadAllText(fileName1);
            Person p3 = JsonConvert.DeserializeObject<Person>(jsonDataFromFile);

            Console.WriteLine(p3.name);
            Console.WriteLine(p3.age);
            Console.WriteLine(p3.city);

            Console.WriteLine("Press Enter for XML Serialization");
            Console.ReadLine();
          
            Console.WriteLine("--------------- XML serialization ----------------");

            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            string fileName2 = @"D:\C# Training\Day 5 Tasks\Files\KPXML1.xml";

            using (FileStream stream = new FileStream(fileName2, FileMode.Create))
            {
                serializer.Serialize(stream, p3);
            }

            Console.WriteLine("XML file is serialized successfully..!!");

            Console.WriteLine("--------------- XML Deserialization ----------------");

            using (StreamReader reader = new StreamReader(fileName2))
            {
                Person p4 = (Person)serializer.Deserialize(reader);
                Console.WriteLine(p4.name);
                Console.WriteLine(p4.age);
                Console.WriteLine(p4.city);
            }
            Console.ReadLine();
        }
    }
}
