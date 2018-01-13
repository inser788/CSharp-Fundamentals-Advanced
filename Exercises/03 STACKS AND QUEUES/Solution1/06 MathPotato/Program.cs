﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_MathPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());
            var circle = new Queue<string>(input.Split());
            int cycle = 1;
            while (circle.Count > 1)
            {
                for (int i = 0; i < number - 1; i++)
                {
                    string reminder = circle.Dequeue();
                    circle.Enqueue(reminder);
                }

                if (PrimeTool.IsPrime(cycle))
                {
                    Console.WriteLine($"Prime {circle.Peek()}");
                }
                else
                {
                    Console.WriteLine($"Removed {circle.Dequeue()}");
                }

                cycle++;
            }

            Console.WriteLine($"Last is {circle.Dequeue()}");
        }

        public static class PrimeTool
        {
            public static bool IsPrime(int candidate)
            {
                // Test whether the parameter is a prime number.
                if ((candidate & 1) == 0)
                {
                    if (candidate == 2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                // Note:
                // ... This version was changed to test the square.
                // ... Original version tested against the square root.
                // ... Also we exclude 1 at the end.
                for (int i = 3; (i * i) <= candidate; i += 2)
                {
                    if ((candidate % i) == 0)
                    {
                        return false;
                    }
                }

                return candidate != 1;
            }
        }
    }

}