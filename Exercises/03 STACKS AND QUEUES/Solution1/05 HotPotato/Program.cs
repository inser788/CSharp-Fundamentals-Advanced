﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());
            var circle=new Queue<string>(input.Split());

            while (circle.Count>1)
            {
                for (int i = 0; i < number-1; i++)
                {
                    string reminder = circle.Dequeue();
                    circle.Enqueue(reminder);
                }

                Console.WriteLine($"Removed {circle.Dequeue()}");
            }

            Console.WriteLine($"Last is {circle.Dequeue()}");
        }
    }
}
