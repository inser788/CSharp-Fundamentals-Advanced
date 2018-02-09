using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Jedi_Galaxy
{
    class JediGalaxy
    {
        static void Main()
        {
            int[] sizeOfMatrix = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rowsCount = sizeOfMatrix[0];
            int colsCount = sizeOfMatrix[1];

            int[][] matrix=new int[rowsCount][];
            for (int row = 0; row < rowsCount; row++)
            {
                matrix[row]=new int[colsCount];
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row][col] = row * colsCount + col;
                }
            }

            long totalSum = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if(input== "Let the Force be with you")
                    break;
                int[] goodStartPosition = input.Split()
                    .Select(int.Parse)
                    .ToArray();

                int goodRowPosition = goodStartPosition[0];
                int goodColPosition = goodStartPosition[1];

                input = Console.ReadLine();

                int[] evilStartPosition = input.Split()
                    .Select(int.Parse)
                    .ToArray();

                int evilRowPosition = evilStartPosition[0];
                int evilColPosition = evilStartPosition[1];

                while (evilRowPosition >= 0 && evilColPosition>=0)
                {
                    if (IsInMatrix(evilRowPosition, evilColPosition, rowsCount, colsCount))
                    {
                        matrix[evilRowPosition][evilColPosition] = 0;
                    }

                    evilRowPosition--;
                    evilColPosition--;
                }

              
                while (goodRowPosition>=0&&goodColPosition<=colsCount-1)
                {
                    if (IsInMatrix(goodRowPosition,goodColPosition,rowsCount,colsCount))
                    {
                        totalSum += matrix[goodRowPosition][goodColPosition];
                    }

                    goodRowPosition--;
                    goodColPosition++;
                }
            }
            Console.WriteLine(totalSum);
        }
        private static bool IsInMatrix(int row, int col, int rows, int cols)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }

    }
}
