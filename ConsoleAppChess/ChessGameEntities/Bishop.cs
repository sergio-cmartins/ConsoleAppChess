using BoardEntities;
using BoardEntities.Enums;

namespace ChessGameEntities
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "B";
        }

        public override bool[,] AvailableMovements()
        {
            int l, c;
            bool[,] allowedPositions = new bool[Board.Lines, Board.Columns];

            //Up & Right
            l = Position.Line - 1;
            c = Position.Column + 1;
            while (Board.ValidPosition(l, c) && (MoveAllowed(l, c) || CaptureAllowed(l, c)))
            {
                allowedPositions[l, c] = true;
                if (CaptureAllowed(l, c))
                {
                    break;
                }
                l--;
                c++;
            }

            //Down & Right
            l = Position.Line + 1;
            c = Position.Column + 1;
            while (Board.ValidPosition(l, c) && (MoveAllowed(l, c) || CaptureAllowed(l, c)))
            {
                allowedPositions[l, c] = true;
                if (CaptureAllowed(l, c))
                {
                    break;
                }
                l++;
                c++;
            }

            //Down & Left
            l = Position.Line + 1;
            c = Position.Column - 1;
            while (Board.ValidPosition(l, c) && (MoveAllowed(l, c) || CaptureAllowed(l, c)))

            {
                allowedPositions[l, c] = true;
                if (CaptureAllowed(l, c))
                {
                    break;
                }
                l++;
                c--;
            }

            //Up & Left
            l = Position.Line - 1;
            c = Position.Column - 1;
            while (Board.ValidPosition(l, c) && (MoveAllowed(l, c) || CaptureAllowed(l, c)))
            {
                allowedPositions[l, c] = true;
                if (CaptureAllowed(l, c))
                {
                    break;
                }
                l--;
                c--;
            }

            return allowedPositions;
        }
    }
}
