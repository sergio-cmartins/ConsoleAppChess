﻿using Exceptions;

namespace BoardEntities
{
    class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            pieces = new Piece[lines, columns];
        }

        public Piece Piece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece Piece(Position position)
        {
            return pieces[position.Line, position.Column];
        }

        public bool ValidPosition(int line, int column)
        {
            if (line >= 0 && line < Lines && column >= 0 && column < Columns)
            {
                return true;
            }
            return false;
        }

        public bool ValidPosition(Position position)
        {
            if (position.Line >= 0 && position.Line < Lines && position.Column >= 0 && position.Column < Columns)
            {
                return true;
            }
            return false;
        }

        public void ValidatePosition(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new BoardException("Invalid Position!");
            }
        }

        public bool PieceExists(Position position)
        {
            ValidatePosition(position);
            return Piece(position) != null;
        }

        public void InsertPiece(Piece piece, Position position)
        {
            if (PieceExists(position))
            {
                throw new BoardException("Position already used");
            }
            pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }

        public Piece RemovePiece(Position position)
        {
            if (Piece(position) == null)
            {
                return null;
            }
            Piece removedPiece = Piece(position);
            removedPiece.Position = null;
            pieces[position.Line, position.Column] = null;
            return removedPiece;
        }

    }
}
