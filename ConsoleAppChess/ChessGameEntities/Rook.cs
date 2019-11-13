﻿using BoardEntities;
using BoardEntities.Enums;

namespace ChessGameEntities
{
    class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "R";
        }
    }
}
