using BoardEntities;
using BoardEntities.Enums;

namespace ChessGameEntities
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "K";
        }

        public override bool[,] AvailableMovements()
        {
            int l, c;
            bool[,] allowedPositions = new bool[Board.Lines, Board.Columns];

            // King can move freely to any one position adjacent to itself.
            for (l = Position.Line - 1; l <= Position.Line + 1; l++)
            {
                for (c = Position.Column - 1; c <= Position.Column + 1; c++)
                {
                    if (l != Position.Line || c != Position.Column) // the piece cannot move to it's own position
                    {
                        if (Board.ValidPosition(l,c) && (MoveAllowed(l, c) || CaptureAllowed(l,c)))
                        {
                            allowedPositions[l, c] = true;
                        }
                    }
                }
            }
            return allowedPositions;
        }
    }
}
