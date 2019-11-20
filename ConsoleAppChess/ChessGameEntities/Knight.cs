using BoardEntities;
using BoardEntities.Enums;

namespace ChessGameEntities
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "N";
        }

        public override bool[,] AvailableMovements()
        {
            int l, c;
            bool[,] allowedPositions = new bool[Board.Lines, Board.Columns];

            // 2U1L
            l = Position.Line - 2;
            c = Position.Column - 1;
            if (Board.ValidPosition(l, c) && (MoveAllowed(l, c) || CaptureAllowed(l, c)))
            {
                allowedPositions[l, c] = true;
            }

            // 2U1R
            l = Position.Line - 2;
            c = Position.Column + 1;
            if (Board.ValidPosition(l, c) && (MoveAllowed(l, c) || CaptureAllowed(l, c)))
            {
                allowedPositions[l, c] = true;
            }

            // 2R1U
            l = Position.Line - 1;
            c = Position.Column + 2;
            if (Board.ValidPosition(l, c) && (MoveAllowed(l, c) || CaptureAllowed(l, c)))
            {
                allowedPositions[l, c] = true;
            }

            // 2R1D
            l = Position.Line + 1;
            c = Position.Column + 2;
            if (Board.ValidPosition(l, c) && (MoveAllowed(l, c) || CaptureAllowed(l, c)))
            {
                allowedPositions[l, c] = true;
            }

            // 2D1R
            l = Position.Line + 2;
            c = Position.Column + 1;
            if (Board.ValidPosition(l, c) && (MoveAllowed(l, c) || CaptureAllowed(l, c)))
            {
                allowedPositions[l, c] = true;
            }

            // 2D1L
            l = Position.Line + 2;
            c = Position.Column - 1;
            if (Board.ValidPosition(l, c) && (MoveAllowed(l, c) || CaptureAllowed(l, c)))
            {
                allowedPositions[l, c] = true;
            }

            // 2L1D
            l = Position.Line + 1;
            c = Position.Column - 2;
            if (Board.ValidPosition(l, c) && (MoveAllowed(l, c) || CaptureAllowed(l, c)))
            {
                allowedPositions[l, c] = true;
            }

            // 2L1U
            l = Position.Line - 1;
            c = Position.Column - 2;
            if (Board.ValidPosition(l, c) && (MoveAllowed(l, c) || CaptureAllowed(l, c)))
            {
                allowedPositions[l, c] = true;
            }

            return allowedPositions;
        }
    }
}
