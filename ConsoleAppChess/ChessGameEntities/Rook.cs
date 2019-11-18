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
            while(Board.ValidPosition(l,c) && MoveAllowed(l, c))
            {
                allowedPositions[l, c] = true;
                if (Board.Piece(l,c) != null && Board.Piece(l,c).Color != Color)
                {
                    break;
                }
                l--;
            }

            //Right
            l = Position.Line;
            c = Position.Column + 1;
            while (Board.ValidPosition(l, c) && MoveAllowed(l, c))
            {
                allowedPositions[l, c] = true;
                if (Board.Piece(l, c) != null && Board.Piece(l, c).Color != Color)
                {
                    break;
                }
                c++;
            }

            //Down
            l = Position.Line + 1;
            c = Position.Column;
            while (Board.ValidPosition(l, c) && MoveAllowed(l, c))
            {
                allowedPositions[l, c] = true;
                if (Board.Piece(l, c) != null && Board.Piece(l, c).Color != Color)
                {
                    break;
                }
                l++;
            }

            //Left
            l = Position.Line;
            c = Position.Column - 1;
            while (Board.ValidPosition(l, c) && MoveAllowed(l, c))
            {
                allowedPositions[l, c] = true;
                if (Board.Piece(l, c) != null && Board.Piece(l, c).Color != Color)
                {
                    break;
                }
                c--;
            }
            return allowedPositions;
        }
    }
}
