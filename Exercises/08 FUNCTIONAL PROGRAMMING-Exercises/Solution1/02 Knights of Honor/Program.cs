﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" \n\t".ToCharArray(),StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            foreach (var item in input)
            {
                Console.WriteLine("Sir "+item);
            }
        }
    }
}
