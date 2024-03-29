﻿using System;
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
                    try
                    {
                        Screen.DisplayChessMatch(chessMatch);

                        Console.Write("\nOrigin: ");
                        Position origin = Screen.ReadChessPosition().ToPosition();
                        chessMatch.ValidateOrigin(origin);

                        Screen.DisplayChessBoard(chessMatch.ChessBoard, origin);
                        Console.Write("\nDestination: ");
                        Position destination = Screen.ReadChessPosition().ToPosition();
                        chessMatch.ValidateDestination(origin, destination);
                        chessMatch.MakeAMove(origin, destination);

                    }
                    catch (ChessMatchException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Screen.DisplayChessMatch(chessMatch);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
