using System;
using System.Collections;
using System.Collections.Generic;

namespace Day_7_Tasks
{
    internal class Program
    {
        static List<string> GetNumberRanges(List<int> numbers)
        {
            List<string> ranges = new List<string>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int start = numbers[i];
                int end = start;

                while (i < numbers.Count - 1 && numbers[i + 1] == end + 1)
                {
                    end = numbers[i + 1];
                    i++;
                }

                if (start == end)
                {
                    ranges.Add(start.ToString());
                }
                else
                {
                    ranges.Add(start + "-" + end);
                }
            }

            return ranges;
        }

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("\n------------------------- MENU ---------------------------\n");

                Console.WriteLine("1. Create a new list from a given list of integers where each integer value is added to 2 and the result value is multiplied by 5");
                Console.WriteLine("2. Create List that can be expressed as a series of groups and individual numbers");
                Console.WriteLine("3. ");

                Console.WriteLine("0. Exit");

                Console.WriteLine("\n--------------------------------------------------------\n");
                Console.Write("Enter Your Choice : ");

                var task = Convert.ToInt32(Console.ReadLine());

                switch (task)
                {
                    case 1:

                        try
                        {
                            List<int> ExistingList = new List<int>();

                            Console.Write("Enter the number of elements you want in List : ");
                            var elementno = Convert.ToInt32(Console.ReadLine());
                            for (int i = 1; i <= elementno; i++)
                            {
                                Console.Write("Enter Element {0} : ", i);
                                var ExixtingElement = Convert.ToInt32(Console.ReadLine());
                                ExistingList.Add(ExixtingElement);
                            }

                            List<int> NewList = new List<int>();

                            foreach (int i in ExistingList)
                            {
                                int NewListData = (i + 2) * 5;
                                NewList.Add(NewListData);
                            }

                            Console.WriteLine("Existing List : " + string.Join(" , ", ExistingList));
                            Console.WriteLine("New list : " + string.Join(" , ", NewList));
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Something Went Wrong ! Please Restart the menu by pressing Enter..");
                        }

                        Console.ReadLine(); //waits for enter button to be pressed to exit console

                        break;

                    case 2:

                        try
                        {
                            List<int> ExistingList = new List<int> { 1, 2, 3, 4, 5, 10, 1, 2, 8, 7, 6, 7, 8, 2, 3, 12 };      //Creating a List that we want to Group by series 

                            List<string> Series = GetNumberRanges(ExistingList);  //Creating a new list of strings called ranges and assigns the value returned by the GetNumberRanges method to it.

                            Console.WriteLine(string.Join(", ", Series));

                        }

                        catch (Exception)
                        {
                            Console.Write("Something Went Wrong ! Please Restart the menu by pressing Enter..");
                        }

                        Console.ReadLine(); //waits for enter button to be pressed to exit console

                        break;


                    case 3:

                        try
                        {

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Something Went Wrong ! Please Restart the menu by pressing Enter..");
                        }

                        Console.ReadLine(); //waits for enter button to be pressed to exit console

                        break;


                    case 0:
                        Environment.Exit(1);// exit

                        break;

                    default:
                        Console.WriteLine("Please Enter 1 to 10");
                        Console.ReadLine(); //waits for enter button to be pressed to exit console
                        break;

                }

            }
            while (true);
        }
    }
}
