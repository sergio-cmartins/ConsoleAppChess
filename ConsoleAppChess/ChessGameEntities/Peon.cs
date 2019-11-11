using BoardEntities;
using BoardEntities.Enums;

namespace ChessGameEntities
{
    class Peon : Piece
    {
        public Peon(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "P";
        }
    }
}
