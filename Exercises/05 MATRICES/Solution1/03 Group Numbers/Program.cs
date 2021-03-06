﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Group_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequance = Console.ReadLine()
                .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] zeroReminder = sequance.Where(x => Math.Abs(x) % 3 == 0).ToArray();
            int[] oneReminder = sequance.Where(x => Math.Abs(x) % 3 == 1).ToArray();
            int[] twoReminder = sequance.Where(x => Math.Abs(x) % 3 == 2).ToArray();

            Console.WriteLine(string.Join(" ",zeroReminder));
            Console.WriteLine(string.Join(" ", oneReminder));
            Console.WriteLine(string.Join(" ", twoReminder));
        }
    }
}
