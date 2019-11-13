using BoardEntities;
using BoardEntities.Enums;

namespace ChessGameEntities
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "p";
        }
    }
}
