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
    }
}
