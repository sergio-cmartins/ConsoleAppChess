using System;
using Board;

namespace ConsoleAppChess
{
    class Program
    {
        static void Main(string[] args)
        {
            Position p = new Position(1, 8);
            Console.WriteLine("Posição: " + p);
        }
    }
}
