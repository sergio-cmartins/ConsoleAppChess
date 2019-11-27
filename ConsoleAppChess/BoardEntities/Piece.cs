using BoardEntities.Enums;

namespace BoardEntities
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MoveCount { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board, Color color)
        {
            Position = null;
            Color = color;
            Board = board;
            MoveCount = 0;
        }

        protected bool MoveAllowed(int line, int column)
        {
            return Board.Piece(line, column) == null;
        }

        protected bool CaptureAllowed(int line, int column)
        {
            Piece p = Board.Piece(line, column);
            return p != null && p.Color != Color;
        }

        public void IncreaseMoveCount()
        {
            MoveCount++;
        }

        public void DecreaseMoveCount()
        {
            MoveCount--;
        }

        public bool ExistsAvailableMoves()
        {
            bool[,] availableMoves = AvailableMovements();
            foreach (bool current in availableMoves)
            {
                if (current)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CanMove(Position destination)
        {
            return AvailableMovements()[destination.Line, destination.Column];
        }

        public abstract bool[,] AvailableMovements();
    }
}
