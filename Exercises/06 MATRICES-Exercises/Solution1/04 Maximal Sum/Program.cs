using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rowsCount = sizeMatrix[0];
            int colsCount = sizeMatrix[1];
            long[][] matrix = new long[rowsCount][];
            for (int row = 0; row < rowsCount; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
            }

            long maxSum = long.MinValue;
            long[][] searchMatrix = new long[3][];
            long[][] currentMatrix = new long[3][];

            for (int i = 0; i < rowsCount-2; i++)
            {
                for (int j = 0; j < colsCount-2; j++)
                {
                    for (int row = 0; row < 3; row++)
                    {
                        currentMatrix[row] = matrix[row+i].Skip(j).Take(3).ToArray();
                    }

                    long currentSum = currentMatrix.Sum(x => x.Sum());
                    if (currentSum>maxSum)
                    {
                        searchMatrix[0] = currentMatrix[0];
                        searchMatrix[1] = currentMatrix[1];
                        searchMatrix[2] = currentMatrix[2];

                        maxSum = currentMatrix.Sum(x => x.Sum());
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            foreach (var row in searchMatrix)
            {
                Console.WriteLine(string.Join(" ",row));
            }
        }
    }
}
