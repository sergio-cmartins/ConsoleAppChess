using BoardEntities;
using BoardEntities.Enums;

namespace ChessGameEntities
{
    class King : Piece
    {
        private readonly ChessMatch chessMatch;

        public King(Board board, Color color, ChessMatch chessMatch) : base(board, color)
        {
            this.chessMatch = chessMatch;
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
                        if (Board.ValidPosition(l, c) && (MoveAllowed(l, c) || CaptureAllowed(l, c)))
                        {
                            allowedPositions[l, c] = true;
                        }
                    }
                }
            }

            //# Special movement - Castling
            if (!chessMatch.Check && MoveCount == 0)
            {
                //King side castling
                if (CastlingAllowed(Position.Line, Position.Column, true))
                {
                    allowedPositions[Position.Line, Position.Column + 2] = true;
                }
                //Queen side castling
                if (CastlingAllowed(Position.Line, Position.Column, false))
                {
                    allowedPositions[Position.Line, Position.Column - 2] = true;
                }

            }
            return allowedPositions;
        }

        private bool CastlingAllowed(int line, int column, bool kingSide)
        {
            int rookColumn = kingSide ? 7 : 0;
            int freeColumn = kingSide ? column + 1 : column - 1;
            if (!RookCanCastle(line, rookColumn))
            {
                return false;
            }

            while (freeColumn != rookColumn)
            {
                if (Board.Piece(line, freeColumn) != null)
                {
                    return false;
                }
                freeColumn = kingSide ? freeColumn + 1 : freeColumn - 1;
            }
            return true;
        }

        private bool RookCanCastle(int line, int column)
        {
            Piece rook = Board.Piece(line, column);
            if (rook != null && rook is Rook && rook.MoveCount == 0)
            {
                return true;
            }
            return false;
        }
    }
}
