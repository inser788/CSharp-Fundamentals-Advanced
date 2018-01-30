﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());
            var listOfNames = Console.ReadLine()
                .Split()
                .ToList();
            listOfNames = listOfNames.Where(x => x.Length <= nameLength)
                .ToList();
            listOfNames.ForEach(x=>Console.WriteLine(x));

        }
    }
}
