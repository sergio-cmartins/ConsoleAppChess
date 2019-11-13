using System;
using BoardEntities;
using BoardEntities.Enums;
using ChessGameEntities;
using Presentation;
using Exceptions;

namespace ConsoleAppChess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);

                board.InsertPiece(new Tower(board, Color.Black), new ChessPosition('a',8).ToPosition());
                board.InsertPiece(new Tower(board, Color.Black), new ChessPosition("h7").ToPosition());
                board.InsertPiece(new King(board, Color.White), new Position(2, 4));

                Screen.PrintBoard(board);
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
