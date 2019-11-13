using System;
using BoardEntities;
using BoardEntities.Enums;

namespace ChessGameEntities
{
    class ChessMatch
    {
        public Board ChessBoard { get; private set; }
        private int turn;
        private Color currentPlayer;

        public ChessMatch()
        {
            ChessBoard = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;

            PutInitialPieces();
        }

        public void ExecuteMove(Position origin, Position destination)
        {
            Piece p = ChessBoard.RemovePiece(origin);
            p.IncreaseMoveCount();
            Piece CapturedPiece = ChessBoard.RemovePiece(destination);
            ChessBoard.InsertPiece(p, destination);

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
