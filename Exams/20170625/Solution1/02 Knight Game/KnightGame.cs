using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Knight_Game
{
    class KnightGame
    {
        static void Main()
        {
            var knightRowsCoordinates=new List<int>();
            var knightColsCoordinates = new List<int>();

            int numberOfRows = int.Parse(Console.ReadLine());
            char[][] chessBoard = GetChessBoard(numberOfRows);

            int rowsCount = chessBoard.Length;
            int colsCount = chessBoard[0].Length;
            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    char currentElement = chessBoard[row][col];
                    if (currentElement=='K')
                    {
                        knightRowsCoordinates.Add(row);
                        knightColsCoordinates.Add(col);
                    }
                }
            }

            

        }


        private static char[][] GetChessBoard(int numberOfRows)
        {
            char[][] matrix = new char[numberOfRows][];

            for (int row = 0; row < numberOfRows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .ToCharArray();
            }

            return matrix;
        }
    }
}
