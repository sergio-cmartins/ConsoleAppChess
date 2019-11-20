using System;
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


        public ChessMatch()
        {
            ChessBoard = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            MatchOver = false;
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
            Piece CapturedPiece = ChessBoard.RemovePiece(destination);
            ChessBoard.InsertPiece(p, destination);
        }

        public void MakeAMove(Position origin, Position destination)
        {
            ExecuteMove(origin, destination);
            Turn++;
            CurrentPlayer = (CurrentPlayer == Color.White) ? Color.Black : Color.White;
        }

        private void PutInitialPieces()
        {
            //Populate White Pieces;
            ChessBoard.InsertPiece(new Rook(ChessBoard, Color.White), new ChessPosition("a1").ToPosition());
            ChessBoard.InsertPiece(new Knight(ChessBoard, Color.White), new ChessPosition("b1").ToPosition());
            ChessBoard.InsertPiece(new Bishop(ChessBoard, Color.White), new ChessPosition("c1").ToPosition());
            ChessBoard.InsertPiece(new Queen(ChessBoard, Color.White), new ChessPosition("d1").ToPosition());
            ChessBoard.InsertPiece(new King(ChessBoard, Color.White), new ChessPosition("e1").ToPosition());
            ChessBoard.InsertPiece(new Bishop(ChessBoard, Color.White), new ChessPosition("f1").ToPosition());
            ChessBoard.InsertPiece(new Knight(ChessBoard, Color.White), new ChessPosition("g1").ToPosition());
            ChessBoard.InsertPiece(new Rook(ChessBoard, Color.White), new ChessPosition("h1").ToPosition());

            ChessBoard.InsertPiece(new Pawn(ChessBoard, Color.White), new ChessPosition("a2").ToPosition());
            ChessBoard.InsertPiece(new Pawn(ChessBoard, Color.White), new ChessPosition("b2").ToPosition());
            ChessBoard.InsertPiece(new Pawn(ChessBoard, Color.White), new ChessPosition("c2").ToPosition());
            ChessBoard.InsertPiece(new Pawn(ChessBoard, Color.White), new ChessPosition("d2").ToPosition());
            ChessBoard.InsertPiece(new Pawn(ChessBoard, Color.White), new ChessPosition("e2").ToPosition());
            ChessBoard.InsertPiece(new Pawn(ChessBoard, Color.White), new ChessPosition("f2").ToPosition());
            ChessBoard.InsertPiece(new Pawn(ChessBoard, Color.White), new ChessPosition("g2").ToPosition());
            ChessBoard.InsertPiece(new Pawn(ChessBoard, Color.White), new ChessPosition("h2").ToPosition());

            //Populate Black Pieces;
            ChessBoard.InsertPiece(new Rook(ChessBoard, Color.Black), new ChessPosition("a8").ToPosition());
            ChessBoard.InsertPiece(new Knight(ChessBoard, Color.Black), new ChessPosition("b8").ToPosition());
            ChessBoard.InsertPiece(new Bishop(ChessBoard, Color.Black), new ChessPosition("c8").ToPosition());
            ChessBoard.InsertPiece(new Queen(ChessBoard, Color.Black), new ChessPosition("d8").ToPosition());
            ChessBoard.InsertPiece(new King(ChessBoard, Color.Black), new ChessPosition("e8").ToPosition());
            ChessBoard.InsertPiece(new Bishop(ChessBoard, Color.Black), new ChessPosition("f8").ToPosition());
            ChessBoard.InsertPiece(new Knight(ChessBoard, Color.Black), new ChessPosition("g8").ToPosition());
            ChessBoard.InsertPiece(new Rook(ChessBoard, Color.Black), new ChessPosition("h8").ToPosition());

            ChessBoard.InsertPiece(new Pawn(ChessBoard, Color.Black), new ChessPosition("a7").ToPosition());
            ChessBoard.InsertPiece(new Pawn(ChessBoard, Color.Black), new ChessPosition("b7").ToPosition());
            ChessBoard.InsertPiece(new Pawn(ChessBoard, Color.Black), new ChessPosition("c7").ToPosition());
            ChessBoard.InsertPiece(new Pawn(ChessBoard, Color.Black), new ChessPosition("d7").ToPosition());
            ChessBoard.InsertPiece(new Pawn(ChessBoard, Color.Black), new ChessPosition("e7").ToPosition());
            ChessBoard.InsertPiece(new Pawn(ChessBoard, Color.Black), new ChessPosition("f7").ToPosition());
            ChessBoard.InsertPiece(new Pawn(ChessBoard, Color.Black), new ChessPosition("g7").ToPosition());
            ChessBoard.InsertPiece(new Pawn(ChessBoard, Color.Black), new ChessPosition("h7").ToPosition());
        }

    }
}
