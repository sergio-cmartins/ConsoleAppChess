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
    }
}
