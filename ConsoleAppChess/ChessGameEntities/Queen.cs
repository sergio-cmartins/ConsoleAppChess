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
    }
}
