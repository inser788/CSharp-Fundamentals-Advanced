using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            int[][] matrix = new int[sizeMatrix][];
            for (int row = 0; row < sizeMatrix; row++)
            {
                matrix[row] = new int[sizeMatrix];
                int[] numbers = Console.ReadLine()
                    .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < sizeMatrix; col++)
                {
                    matrix[row][col] = numbers[col];
                }
            }
           
            int sumFirst = 0;
            int sumLast = 0;
            int indexFirst = 0;
            int indexLast = sizeMatrix - 1;
            foreach (var row in matrix)
            {
                sumFirst += row.ElementAt(indexFirst);
                sumLast += row.ElementAt(indexLast);
                indexFirst++;
                indexLast--;
            }

            int absoluteDeviation = Math.Abs(sumFirst - sumLast);
            Console.WriteLine(absoluteDeviation);
        }
    }
}
