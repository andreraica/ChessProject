using System;
using ChessProject.board;
using ChessProject.chess;

namespace ChessProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Board tab = new Board(8, 8);

            tab.colPiece(new Tower(tab, Color.Black), new Position(0, 0));
            tab.colPiece(new Tower(tab, Color.Black), new Position(1, 3));
            tab.colPiece(new King(tab, Color.Black), new Position(2, 4));

            Screen.imprBoard(tab);
        }
    }
}
