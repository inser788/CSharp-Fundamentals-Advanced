using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rowsCount = matrixSize[0];
            int colsCount = matrixSize[1];
            string[][] matrix = new string[rowsCount][];
            for (int row = 0; row < rowsCount; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }

            int counter = 0;
            for (int row = 0; row < rowsCount - 1; row++)
            {
                for (int col = 0; col < colsCount - 1; col++)
                {
                    if (matrix[row][col] == matrix[row][col + 1]
                        && matrix[row][col] == matrix[row + 1][col]
                        && matrix[row][col] == matrix[row + 1][col + 1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
