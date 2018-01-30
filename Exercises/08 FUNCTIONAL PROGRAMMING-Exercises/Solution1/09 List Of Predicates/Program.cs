﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_List_Of_Predicates
{
    class Program
    {
        static void Main()
        {
            int endOfRange = int.Parse(Console.ReadLine());
            var listOfDivisible = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Distinct()
                .ToList();
            int maxNumber = listOfDivisible.Max();
            var searcedNumbers = new List<int>();
            for (int i = maxNumber; i <= endOfRange; i+=maxNumber)
            {
                var currentNumber = i;

                if (listOfDivisible.Any(n => currentNumber % n != 0))
                {
                    continue;
                }

                searcedNumbers.Add(currentNumber);
            }

            if (searcedNumbers.Count != 0)
            {
                Console.WriteLine(string.Join(" ", searcedNumbers));
            }
        }
    }
}
