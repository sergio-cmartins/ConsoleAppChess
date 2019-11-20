using BoardEntities;
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

            //Right
            l = Position.Line;
            c = Position.Column + 1;
            while (Board.ValidPosition(l, c) && (MoveAllowed(l, c) || CaptureAllowed(l, c)))
            {
                allowedPositions[l, c] = true;
                if (CaptureAllowed(l, c))
                {
                    break;
                }
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
