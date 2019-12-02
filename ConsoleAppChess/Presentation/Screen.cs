using System;
using System.Collections.Generic;
using BoardEntities;
using BoardEntities.Enums;
using ChessGameEntities;

namespace Presentation
{
    class Screen
    {
        public static void DisplayChessMatch(ChessMatch chessMatch)
        {
            Console.Clear();
            DisplayChessBoard(chessMatch.ChessBoard);
            DisplayCapturedPieces(chessMatch);
            Console.WriteLine("\nTurn: {0}, Current Player: {1}", chessMatch.Turn, chessMatch.CurrentPlayer);
            if (chessMatch.MatchOver)
            {
                Console.WriteLine(chessMatch.OposingPlayer + " player CHECKMATED, " + chessMatch.CurrentPlayer + " player Won!");
            } else if (chessMatch.Check)
            {
                Console.WriteLine("CHECK!");
            }
        }

        public static void DisplayCapturedPieces(ChessMatch chessMatch)
        {
            Console.WriteLine("\nCaptured Pieces: ");
            Console.Write("White: ");
            DisplaySetPieces(chessMatch.CapturedPieces(Color.White));

            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Black: ");
            DisplaySetPieces(chessMatch.CapturedPieces(Color.Black));
            Console.ForegroundColor = aux;

            Console.WriteLine();
        }

        public static void DisplaySetPieces(HashSet<Piece> pieces)
        {
            bool firstPiece = true;
            Console.Write("[");
            foreach (Piece piece in pieces)
            {

                if (firstPiece)
                {
                    Console.Write(piece);
                    firstPiece = false;
                }
                else
                {
                    Console.Write("," + piece);
                }
            }
            Console.WriteLine("]");


        }

        public static void DisplayChessBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    DisplayPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void DisplayChessBoard(Board board, Position origin)
        {
            Console.Clear();
            ConsoleColor originalBackground = Console.BackgroundColor;
            bool[,] allowedPositions = board.Piece(origin).AvailableMovements();


            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (allowedPositions[i, j])
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        DisplayPiece(board.Piece(i, j));
                        Console.BackgroundColor = originalBackground;
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
            if (piece != null)
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
            else
            {
                Console.Write("- ");
            }
        }

        public static ChessPosition ReadChessPosition()
        {
            return new ChessPosition(Console.ReadLine());
        }
    }
}
