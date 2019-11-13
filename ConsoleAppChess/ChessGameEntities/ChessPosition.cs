using System;
using BoardEntities;

namespace ChessGameEntities
{
    class ChessPosition
    {
        public char Column { get; set; }
        public int Line { get; set; }

        public ChessPosition(char column, int line)
        {
            Column = char.ToLower(column);
            Line = line;
        }

        public ChessPosition(string algNot)
        {
            Column = char.ToLower(algNot[0]);
            Line = algNot[1] - '0';
        }

        public Position ToPosition()
        {
            return new Position(8 - Line, Column - 'a');
        }

        public override string ToString()
        {
            return "" + Column + Line;
        }
    }
}
