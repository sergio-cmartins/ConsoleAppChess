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
                ChessMatch chessMatch = new ChessMatch();
                while (!chessMatch.MatchOver)
                {
                    Screen.DisplayChessBoard(chessMatch.ChessBoard);
                    Console.Write("\nOrigin: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    Screen.DisplayChessBoard(chessMatch.ChessBoard, origin);
                    Console.Write("\nDestination: ");
                    Position destination = Screen.ReadChessPosition().ToPosition();

                    chessMatch.ExecuteMove(origin, destination);
                }
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
