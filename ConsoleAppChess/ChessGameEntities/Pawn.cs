using BoardEntities;
using BoardEntities.Enums;
using System;

namespace ChessGameEntities
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "p";
        }

        public override bool[,] AvailableMovements()
        {
            int l, c, move;
            bool[,] allowedPositions = new bool[Board.Lines, Board.Columns];

            //for pawn movement whe must check if it's a white or black piece to define it's forward movement
            move = (Color == Color.White) ? -1 : +1;

            // Movement
            c = Position.Column;
            l = Position.Line + move;
            while (Board.ValidPosition(l, c) && MoveAllowed(l, c) && (Math.Abs(Position.Line - l) <= 2))
            {
                if (Board.ValidPosition(l, c) && MoveAllowed(l, c))
                {
                    allowedPositions[l, c] = true;
                }
                if (MoveCount != 0)
                {
                    break;
                }
                l += move;
            }

            //Capture Right
            l = Position.Line + move;
            c = Position.Column + 1;
            if (Board.ValidPosition(l, c) && CaptureAllowed(l, c))
            {
                allowedPositions[l, c] = true;
            }

            //Capture Left
            l = Position.Line + move;
            c = Position.Column - 1;
            if (Board.ValidPosition(l, c) && CaptureAllowed(l, c))
            {
                allowedPositions[l, c] = true;
            }

            return allowedPositions;
        }
    }
}
