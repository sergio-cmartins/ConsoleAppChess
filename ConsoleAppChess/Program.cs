﻿using System;
using BoardEntities;
using BoardEntities.Enums;
using Presentation;
using ChessGameEntities;

namespace ConsoleAppChess
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            board.InsertPiece(new Tower(board, Color.Black), new Position(0, 0));
            board.InsertPiece(new Tower(board, Color.Black), new Position(1, 3));
            board.InsertPiece(new King(board, Color.Black), new Position(2, 4));

            Screen.PrintBoard(board);

            Console.ReadKey();
        }
    }
}
