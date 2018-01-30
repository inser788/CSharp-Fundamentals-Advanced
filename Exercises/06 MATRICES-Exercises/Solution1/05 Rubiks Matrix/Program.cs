using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Rubiks_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = GetMatrix();
            var rubikMatrix = GetRubikMatrix(matrix);
            GetRubikMatrixToOriginal(rubikMatrix, matrix);
            Console.WriteLine();
        }

        private static void GetRubikMatrixToOriginal(int[][] rubikMatrix, int[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (rubikMatrix[row][col]==matrix[row][col])
                    {
                        Console.WriteLine($"No swap required");
                        continue;
                    }

                    for (int searchRow = 0; searchRow < rows; searchRow++)
                    {
                        bool isMatch = false;
                        for (int searchCol = 0; searchCol < cols; searchCol++)
                        {
                            if (rubikMatrix[searchRow][searchCol]==matrix[row][col])
                            {
                                rubikMatrix[searchRow][searchCol] = rubikMatrix[row][col];
                                rubikMatrix[row][col] = matrix[row][col];
                                Console.WriteLine($"Swap ({row}, {col}) with ({searchRow}, {searchCol})");
                                isMatch = true;
                                break;
                                ;
                            }
                        }

                        if (isMatch) break;
                    }
                }
            }
        }

        private static int[][] GetRubikMatrix(int[][] matrix)
        {
            int commandsCount = int.Parse(Console.ReadLine());
            int[][] rubikMatrix = GetCopyOfFirstMatrix(matrix);
            for (int i = 0; i < commandsCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                int elementRowCol = int.Parse(input[0]);
                string direction = input[1];
                int moves = int.Parse(input[2]);

                if (direction == "up" || direction == "down")
                {
                    rubikMatrix = GetRotateColumns(rubikMatrix, elementRowCol, direction, moves);
                }
                else if (direction == "left" || direction == "right")
                {
                    rubikMatrix = GetRotateRows(rubikMatrix, elementRowCol, direction, moves);
                }
            }

            return rubikMatrix;
        }

        private static int[][] GetRotateRows(int[][] matrix, int elementRow, string direction, int moves)
        {
            var rubikMatrix = GetCopyOfFirstMatrix(matrix);
            var rows = matrix.Length;
            var cols = matrix[0].Length;

            // direction RIGHT => increase COL index, direction LEFT => decrease COL index
            // keep COL index unchanged
            moves %= rows;
            if (direction == "left")
            {
                moves = -moves;
            }

            for (int col = 0; col < rows; col++)
            {
                var modifiedCol = (col + moves) % rows;
                while (modifiedCol < 0)
                {
                    modifiedCol += rows;
                }
                rubikMatrix[elementRow][modifiedCol] = matrix[elementRow][col];
            }
            return rubikMatrix;
        }


        private static int[][] GetRotateColumns(int[][] matrix, int elementCol, string direction, int moves)
        {
            var rubikMatrix = GetCopyOfFirstMatrix(matrix);
            var rows = matrix.Length;
            var cols = matrix[0].Length;

            // direction DOWN => increase ROW index, direction UP => decrease ROW index
            // keep COL index unchanged
            moves %= rows;
            if (direction == "up")
            {
                moves = -moves;
            }

            for (int row = 0; row < rows; row++)
            {
                var modifiedRow = (row + moves) % rows;
                while (modifiedRow < 0)
                {
                    modifiedRow += rows;
                }
                rubikMatrix[modifiedRow][elementCol] = matrix[row][elementCol];
            }
            return rubikMatrix;
        }

        private static int[][] GetCopyOfFirstMatrix(int[][] matrix)
        {
            int[][] copyMatrix = new int[matrix.Length][];
            for (int i = 0; i < copyMatrix.Length; i++)
            {
                copyMatrix[i] = matrix[i].ToArray();
            }

            return copyMatrix;
        }

        private static int[][] GetMatrix()
        {
            int[] sizeMatrix = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rowsCount = sizeMatrix[0];
            int colsCount = sizeMatrix[1];
            int[][] matrix=new int[rowsCount][];
            int number = 1;

            for (int row = 0; row < rowsCount; row++)
            {
                matrix[row]=new int[colsCount];
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row][col] = number++;
                }
            }

            return matrix;
        }
    }
}
