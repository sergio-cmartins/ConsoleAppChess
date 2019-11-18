﻿using BoardEntities;
using BoardEntities.Enums;

namespace ChessGameEntities
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "Q";
        }

        public override bool[,] AvailableMovements()
        {
            bool[,] allowedPositions = new bool[Board.Lines, Board.Columns];

            //Piece can never move to it's own position
            allowedPositions[Position.Line, Position.Column] = false;

            return allowedPositions;
        }
    }
}
