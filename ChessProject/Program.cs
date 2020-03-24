using System;
using ChessProject.board;

namespace ChessProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Board tab = new Board(8, 8);
            Screen.imprBoard(tab);
        }
    }
}
