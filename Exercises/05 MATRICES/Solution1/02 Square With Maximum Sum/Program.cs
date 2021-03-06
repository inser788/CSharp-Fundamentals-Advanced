﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] matrix=new int[matrixSize[0]][];
            for (int i = 0; i < matrix.Length; i++)
            {
                var input = Console.ReadLine()
                    .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                matrix[i]=new int[input.Length];
                for (int j = 0; j < input.Length; j++)
                {
                    matrix[i][j] = int.Parse(input[j]);
                }
            }

            long maxSum = int.MinValue;
            int[][] array=new int[2][];
            array[0]=new int[2];
            array[1] = new int[2];
            for (int row = 0; row < matrix.Length-1; row++)
            {
                for (int col = 0; col < matrix[row].Length-1; col++)
                {
                    long currentSum = matrix[row][col]
                                      + matrix[row][col+1]
                                      + matrix[row+1][col]
                                      + matrix[row+1][col+1];
                    if (currentSum>maxSum)
                    {
                        array[0][0] = matrix[row][col];
                        array[0][1] = matrix[row][col + 1];
                        array[1][0] = matrix[row + 1][col];
                        array[1][1] = matrix[row + 1][col + 1];
                        maxSum = currentSum;
                    }
                }
            }
            foreach (var row in array)
            {
                foreach (var element in row)
                {
                    Console.Write(element+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(array.Sum(x=>x.Sum()));
        }
    }
}
