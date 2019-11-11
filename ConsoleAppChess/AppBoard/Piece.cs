using System;
using System.Collections.Generic;
using System.Text;
using AppBoard.Enums;

namespace AppBoard
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int Moves { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Position position, Board board, Color color)
        {
            Position = position;
            Color = color;
            Board = board;
            Moves = 0;
        }
    }
}
