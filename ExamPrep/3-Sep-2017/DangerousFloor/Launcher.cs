namespace DangerousFloor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Launcher
    {
        public static void Main()
        {
            char[][] board = new char[8][];

            for (int i = 0; i < 8; i++)
            {
                board[i] = string.Join("", Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)).ToCharArray();
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                char figureType = input[0];
                int figureStartingRow = ((input[1]) - '0');
                int figureStartingColumn = ((input[2]) - '0');

                int figureTargetRow = ((input[4]) - '0');
                int figureTargetColumn = ((input[5]) - '0');

                if (board[figureStartingRow][figureStartingColumn] != figureType)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }

                if (!CheckMoveValidity(figureType, board, figureStartingRow, figureTargetRow, figureStartingColumn, figureTargetColumn))
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }

                if (figureTargetRow < 0 || figureTargetRow > 7)
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }

                if (figureTargetColumn < 0 || figureTargetColumn > 7)
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }

                board[figureStartingRow][figureStartingColumn] = 'x';
                board[figureTargetRow][figureTargetColumn] = figureType;
            }
        }

        public static bool CheckMoveValidity(char pieceType, char[][] board, int startingRow, int targetRow, int startingColumn, int TargetColumn)
        {
            if (startingColumn == TargetColumn && startingRow == targetRow)
            {
                return false;
            }


            if (pieceType == 'P')
            {
                if (TargetColumn != startingColumn)
                {
                    return false;
                }
                else if (targetRow != startingRow - 1)
                {
                    return false;
                }
            }

            if (pieceType == 'B')
            {
                if (Math.Abs(targetRow - startingRow) != Math.Abs(TargetColumn - startingColumn))
                {
                    return false;
                }
            }

            if (pieceType == 'R')
            {
                if (startingRow != targetRow && startingColumn != TargetColumn)
                {
                    return false;
                }
            }

            if (pieceType == 'K')
            {
                if (Math.Abs((targetRow) - (startingRow)) > 1)
                {
                    return false;
                }

                if (Math.Abs((TargetColumn) - (startingColumn)) > 1)
                {
                    return false;
                }
            }

            if (pieceType == 'Q')
            {
                bool canMoveAsBishop = CheckMoveValidity('B', board, startingRow, targetRow, startingColumn, TargetColumn);
                bool canMoveAsRook = CheckMoveValidity('R', board, startingRow, targetRow, startingColumn, TargetColumn);

                return (canMoveAsBishop || canMoveAsRook);
            }

            return true;
        }
    }
}