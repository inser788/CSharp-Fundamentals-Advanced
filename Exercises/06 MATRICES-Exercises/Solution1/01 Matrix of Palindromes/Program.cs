using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Matrix_of_Palindromes
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
            string[][] matrix=new string[rowsCount][];
            for (int row = 0; row < rowsCount; row++)
            {
                matrix[row]=new string[colsCount];

                for (int col = 0; col < colsCount; col++)
                {
                    StringBuilder builderPalindrome=new StringBuilder();
                    char firstLetter = (char) ('a' + row);
                    char secondLetter = (char) (firstLetter + col);
                    builderPalindrome
                        .Append(firstLetter)
                        .Append(secondLetter)
                        .Append(firstLetter);
                    matrix[row][col] = builderPalindrome.ToString();
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ",row));
            }
        }
    }
}
