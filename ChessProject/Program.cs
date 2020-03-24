using System;
using ChessProject.board;
using ChessProject.chess;

namespace ChessProject
{
    class Program
    {
        static void Main(string[] args)
        {
            PositionChess pos = new PositionChess('c', 7);
            Console.WriteLine(pos.toPosition());
        }
    }
}
