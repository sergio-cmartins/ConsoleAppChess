using System;

namespace Exceptions
{
    class ChessMatchException : ApplicationException
    {
        public ChessMatchException(string message) : base(message)
        {
        }
    }
}
