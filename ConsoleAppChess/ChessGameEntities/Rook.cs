using BoardEntities;
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

        public override bool[,] AvailableMovements()
        {
            int l, c;
            bool[,] allowedPositions = new bool[Board.Lines, Board.Columns];

            //Up
            l = Position.Line - 1;
            c = Position.Column;
            while (Board.ValidPosition(l, c) && (MoveAllowed(l, c) || CaptureAllowed(l, c)))
            {
                allowedPositions[l, c] = true;
                if (CaptureAllowed(l, c))
                {
                    break;
                }
                l--;
            }

            //Right
            l = Position.Line;
            c = Position.Column + 1;
            while (Board.ValidPosition(l, c) && (MoveAllowed(l, c) || CaptureAllowed(l, c)))
            {
                allowedPositions[l, c] = true;
                if (CaptureAllowed(l,c))
                {
                    break;
                }
                c++;
            }

            //Down
            l = Position.Line + 1;
            c = Position.Column;
            while (Board.ValidPosition(l, c) && (MoveAllowed(l, c) || CaptureAllowed(l, c)))
                {
                    allowedPositions[l, c] = true;
                if (CaptureAllowed(l, c))
                {
                    break;
                }
                l++;
            }

            //Left
            l = Position.Line;
            c = Position.Column - 1;
            while (Board.ValidPosition(l, c) && (MoveAllowed(l, c) || CaptureAllowed(l, c)))

                {
                    allowedPositions[l, c] = true;
                if (CaptureAllowed(l, c))
                {
                    break;
                }
                c--;
            }

            return allowedPositions;
        }
    }
}
