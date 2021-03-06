﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Command_Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfElements = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            int elementsLength = listOfElements.Count();
            int lastIndexOfElements = elementsLength - 1;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                    break;
                string[] command = input.Split().ToArray();
                string operation = command.First();
                if (operation == "reverse")
                {
                    int startIndex = int.Parse(command.Skip(2).First());
                    int count = int.Parse(command.Last());
                    long lastIndexReversed = startIndex + count;
                    if (startIndex < 0 || startIndex > lastIndexOfElements
                        || count < 0 || count > elementsLength)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        continue;
                    }
                    if (lastIndexReversed > elementsLength)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        continue;
                    }
                    listOfElements.Reverse(startIndex, count);
                }
                else if (operation == "sort")
                {
                    int startIndex = int.Parse(command.Skip(2).First());
                    int count = int.Parse(command.Last());
                    long lastIndexSort = startIndex + count;
                    if (startIndex < 0 || startIndex > lastIndexOfElements
                        || count < 0 || count > elementsLength)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        continue;
                    }
                    if (lastIndexSort > elementsLength)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        continue;
                    }
                    listOfElements.Sort(startIndex, count, null);
                }
                else if (operation == "rollLeft")
                {
                    int count = int.Parse(command.Skip(1).First());
                    int timesRow = count % elementsLength;
                  
                    if (count<0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        continue;
                    }
                    for (int i = 0; i < timesRow; i++)
                    {
                        listOfElements.Add(listOfElements.ElementAt(0));
                        listOfElements.RemoveAt(0);
                    }

                }
                else if(operation=="rollRight")
                {
                    int count = int.Parse(command.Skip(1).First());
                    int timesRow = count % elementsLength;
                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        continue;
                    }
                    listOfElements.Reverse();
                    for (int i = 0; i < timesRow; i++)
                    {
                        listOfElements.Add(listOfElements.ElementAt(0));
                        listOfElements.RemoveAt(0);
                    }
                    listOfElements.Reverse();
                }

            }
            Console.WriteLine("[" + string.Join(", ", listOfElements) + "]");
        }
    }
}
