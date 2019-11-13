using System;
using BoardEntities;
using BoardEntities.Enums;
using ChessGameEntities;

namespace Presentation
{
    class Screen
    {
        public static void DisplayChessBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        DisplayPiece(board.Piece(i, j));
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void DisplayPiece(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.Write(piece + " ");
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(piece + " ");
                Console.ForegroundColor = aux;

            }
        }

        public static ChessPosition ReadChessPosition()
        {
            return new ChessPosition(Console.ReadLine());
        }
    }
}
