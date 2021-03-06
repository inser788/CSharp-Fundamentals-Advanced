﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] sequance = new long[n][];
            long currentWidth = 1;
            for (int i = 0; i < n; i++)
            {
                sequance[i] = new long[currentWidth];
                long[] currentRow = sequance[i];
                currentRow[0] = 1;
                currentRow[currentRow.Length - 1] = 1;
                currentWidth++;
                if (currentRow.Length > 2)
                {
                    for (int j = 1; j < currentRow.Length - 1; j++)
                    {
                        long[] previousRow = sequance[i - 1];
                        long previousSum = previousRow[j] + previousRow[j - 1];
                        currentRow[j] = previousSum;
                    }
                }
            }

            foreach (var row in sequance)
            {
                foreach (var element in row)
                {
                    Console.Write(element+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
