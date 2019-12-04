using System;
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
        public bool Check { get; private set; }
        public Piece EnPassantTarget { get; private set; }
        public Color OposingPlayer
        {
            get
            {
                return CurrentPlayer == Color.White ? Color.Black : Color.White;
            }
        }
        private HashSet<Piece> boardPieces;
        private HashSet<Piece> capturedPieces;

        public ChessMatch()
        {
            ChessBoard = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            MatchOver = false;
            Check = false;
            boardPieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            EnPassantTarget = null;
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

        public Piece ExecuteMove(Position origin, Position destination)
        {
            Piece p = ChessBoard.RemovePiece(origin);
            p.IncreaseMoveCount();
            Piece capturedPiece = ChessBoard.RemovePiece(destination);
            ChessBoard.InsertPiece(p, destination);
            if (capturedPiece != null)
            {
                capturedPieces.Add(capturedPiece);
            }

            //#Special Move KingSide Castling
            if (p is King && destination.Column == origin.Column + 2)
            {
                Position pRook = new Position(origin.Line, 7);
                Piece r = ChessBoard.RemovePiece(pRook);
                r.IncreaseMoveCount();
                ChessBoard.InsertPiece(r, new Position(destination.Line, destination.Column - 1));
            }

            //#Special Move QueenSide Castling
            if (p is King && destination.Column == origin.Column - 2)
            {
                Position pRook = new Position(origin.Line, 0);
                Piece r = ChessBoard.RemovePiece(pRook);
                r.IncreaseMoveCount();
                ChessBoard.InsertPiece(r, new Position(destination.Line, destination.Column + 1));
            }

            //#Special Move En Passant
            if (p is Pawn && EnPassantTarget != null && ChessBoard.Piece(origin.Line, destination.Column) == EnPassantTarget)
            {
                capturedPiece = ChessBoard.RemovePiece(EnPassantTarget.Position);
                if (capturedPiece != null)
                {
                    capturedPieces.Add(capturedPiece);
                }
            }

            return capturedPiece;
        }

        public void UndoMove(Position origin, Position destination, Piece capturedPiece)
        {
            Piece p = ChessBoard.RemovePiece(destination);
            p.DecreaseMoveCount();
            if (capturedPiece != null)
            {
                if (EnPassantTarget != null && EnPassantTarget.Position == null) // check if last move was enPassant
                {
                    Position enPassantOriginal = new Position(origin.Line, destination.Column);
                    ChessBoard.InsertPiece(capturedPiece, enPassantOriginal);
                }
                else
                {
                    ChessBoard.InsertPiece(capturedPiece, destination);
                }
                capturedPieces.Remove(capturedPiece);
            }
            ChessBoard.InsertPiece(p, origin);

            //#Special Move KingSide Castling
            if (p is King && destination.Column == origin.Column + 2)
            {
                Position pRook = new Position(destination.Line, destination.Column - 1);
                Piece r = ChessBoard.RemovePiece(pRook);
                r.DecreaseMoveCount();
                ChessBoard.InsertPiece(r, new Position(origin.Line, 7));
            }

            //#Special Move QueenSide Castling
            if (p is King && destination.Column == origin.Column - 2)
            {
                Position pRook = new Position(destination.Line, destination.Column + 1);
                Piece r = ChessBoard.RemovePiece(pRook);
                r.DecreaseMoveCount();
                ChessBoard.InsertPiece(r, new Position(origin.Line, 0));
            }
        }

        public void MakeAMove(Position origin, Position destination)
        {
            Piece capturedPiece = ExecuteMove(origin, destination);
            if (PlayerInCheck(CurrentPlayer))
            {
                UndoMove(origin, destination, capturedPiece);
                throw new ChessMatchException("You cannot make a move that puts you in Check!");
            }

            Piece currentPiece = ChessBoard.Piece(destination);
            int promotionRank = (CurrentPlayer == Color.White) ? 0 : 7;
            EnPassantTarget = null;

            //# Special Moves - Pawn
            if (currentPiece is Pawn)
            {
                //check for en Passant vulnerability
                if (Math.Abs(destination.Line - origin.Line) == 2)
                {
                    EnPassantTarget = currentPiece;
                }

                //pawn promotion
                else if (destination.Line == promotionRank)
                {
                    currentPiece = ChessBoard.RemovePiece(destination);
                    boardPieces.Remove(currentPiece);
                    Piece promotedPiece = new Queen(ChessBoard, CurrentPlayer);
                    ChessBoard.InsertPiece(promotedPiece, destination);
                    boardPieces.Add(promotedPiece);
                }
            }

            Check = PlayerInCheck(OpposingPlayer(CurrentPlayer));
            if (PlayerCheckMated(OpposingPlayer(CurrentPlayer)))
            {
                MatchOver = true;
            }
            else
            {
                Turn++;
                CurrentPlayer = (CurrentPlayer == Color.White) ? Color.Black : Color.White;
            }
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
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        private Color OpposingPlayer(Color color)
        {
            return (color == Color.White) ? Color.Black : Color.White;
        }

        private Piece ActiveKing(Color color)
        {
            foreach (Piece piece in ActivePieces(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public bool PlayerInCheck(Color color)
        {
            Piece k = ActiveKing(color);
            if (k == null)
            {
                throw new ChessMatchException("There is no " + k.Color + " king");
            }
            foreach (Piece piece in ActivePieces(OpposingPlayer(color)))
            {
                bool[,] moves = piece.AvailableMovements();
                if (moves[k.Position.Line, k.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool PlayerCheckMated(Color color)
        {
            if (!PlayerInCheck(color))
            {
                return false;
            }
            foreach (Piece piece in ActivePieces(color))
            {
                bool[,] moves = piece.AvailableMovements();
                for (int i = 0; i < ChessBoard.Lines; i++)
                {
                    for (int j = 0; j < ChessBoard.Columns; j++)
                    {
                        if (moves[i, j])
                        {
                            Position origin = piece.Position;
                            Position destination = new Position(i, j);
                            Piece capturedPiece = ExecuteMove(origin, destination);
                            bool inCheck = PlayerInCheck(color);
                            UndoMove(origin, destination, capturedPiece);
                            if (!inCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private void PutInitialPieces()
        {
            /*
            // Test of undo for check into en Passant
            PutChessPiece(new King(ChessBoard, Color.Black, this), 'e', 8);
            PutChessPiece(new Queen(ChessBoard, Color.Black), 'd', 8);
            PutChessPiece(new Pawn(ChessBoard, Color.Black, this), 'c', 7);
            PutChessPiece(new Pawn(ChessBoard, Color.Black, this), 'e', 7);

            PutChessPiece(new King(ChessBoard, Color.White, this), 'd', 1);
            PutChessPiece(new Queen(ChessBoard, Color.White), 'e', 1);
            PutChessPiece(new Pawn(ChessBoard, Color.White, this), 'd', 2);
            PutChessPiece(new Pawn(ChessBoard, Color.White, this), 'e', 2);
            */
            //Populate White Pieces;
            PopulateFirstRank(Color.White);
            PopulatePawns(Color.White);

            //Populate Black Pieces;
            PopulateFirstRank(Color.Black);
            PopulatePawns(Color.Black);
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
            PutChessPiece(new King(ChessBoard, color, this), 'e', line);
        }

        private void PopulatePawns(Color color)
        {
            int line = (color == Color.White) ? 2 : 7;
            for (char i = 'a'; i <= 'h'; i++)
            {
                PutChessPiece(new Pawn(ChessBoard, color, this), i, line);
            }
        }

        public void PutChessPiece(Piece piece, char column, int line)
        {
            ChessBoard.InsertPiece(piece, new ChessPosition(column, line).ToPosition());
            boardPieces.Add(piece);
        }
    }
}
