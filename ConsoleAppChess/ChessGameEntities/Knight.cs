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
            return "H";
        }
    }
}
