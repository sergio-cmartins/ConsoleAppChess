using System.Collections.Generic;
using BoardEntities;
using BoardEntities.Enums;
using Exceptions;

namespace ChessGameEntities
{
    class ChessMatch
    {
        public Board ChessBoard { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool MatchOver { get; private set; }
        private HashSet<Piece> boardPieces;
        private HashSet<Piece> capturedPieces;


        public ChessMatch()
        {
            ChessBoard = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            MatchOver = false;
            boardPieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            PutInitialPieces();
        }

        public void ValidateOrigin(Position origin)
        {
            ChessBoard.ValidatePosition(origin);
            if (ChessBoard.Piece(origin) == null)
            {
                throw new ChessMatchException("There is no Piece in this Position.");
            }
            if (ChessBoard.Piece(origin).Color != CurrentPlayer)
            {
                throw new ChessMatchException("The choosen piece isn't yours");
            }
            if (!ChessBoard.Piece(origin).ExistsAvailableMoves())
            {
                throw new ChessMatchException("There are no Moves for this Piece");
            }
        }

        public void ValidateDestination(Position origin, Position destination)
        {
            ChessBoard.ValidatePosition(destination);
            if (!ChessBoard.Piece(origin).CanMove(destination))
            {
                throw new ChessMatchException("This move is not Allowed.");
            }
        }

        public void ExecuteMove(Position origin, Position destination)
        {
            Piece p = ChessBoard.RemovePiece(origin);
            p.IncreaseMoveCount();
            Piece capturedPiece = ChessBoard.RemovePiece(destination);
            ChessBoard.InsertPiece(p, destination);
            if (capturedPiece != null)
            {
                capturedPieces.Add(capturedPiece);
            }
        }

        public void MakeAMove(Position origin, Position destination)
        {
            ExecuteMove(origin, destination);
            Turn++;
            CurrentPlayer = (CurrentPlayer == Color.White) ? Color.Black : Color.White;
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in capturedPieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            return aux;
        }

        public HashSet<Piece> ActivePieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in boardPieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            aux.ExceptWith(capturedPieces);
            return aux;
        }

        public void PutChessPiece(Piece piece, char column, int line)
        {
            ChessBoard.InsertPiece(piece, new ChessPosition(column, line).ToPosition());
            boardPieces.Add(piece);
        }

        private void PopulateFirstRank(Color color)
        {
            int line = (color == Color.White) ? 1 : 8;
            PutChessPiece(new Rook(ChessBoard, color), 'a', line);
            PutChessPiece(new Rook(ChessBoard, color), 'h', line);
            PutChessPiece(new Knight(ChessBoard, color), 'b', line);
            PutChessPiece(new Knight(ChessBoard, color), 'g', line);
            PutChessPiece(new Bishop(ChessBoard, color), 'c', line);
            PutChessPiece(new Bishop(ChessBoard, color), 'f', line);
            PutChessPiece(new Queen(ChessBoard, color), 'd', line);
            PutChessPiece(new King(ChessBoard, color), 'e', line);
        }

        private void PopulatePawns(Color color)
        {
            int line = (color == Color.White) ? 2 : 7;
            for (char i = 'a'; i <= 'h'; i++)
            {
                PutChessPiece(new Pawn(ChessBoard, color), i, line);
            }
        }

        private void PutInitialPieces()
        {
            //Populate White Pieces;
            PopulateFirstRank(Color.White);
            PopulatePawns(Color.White);

            //Populate Black Pieces;
            PopulateFirstRank(Color.Black);
            PopulatePawns(Color.Black);
        }

    }
}
