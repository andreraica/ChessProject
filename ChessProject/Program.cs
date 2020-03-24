using System;
using ChessProject.board;
using ChessProject.chess;

namespace ChessProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board tab = new Board(8, 8);

                tab.colPiece(new Tower(tab, Color.Black), new Position(0, 0));
                tab.colPiece(new Tower(tab, Color.Black), new Position(1, 3));
                tab.colPiece(new King(tab, Color.Black), new Position(0, 2));

                tab.colPiece(new King(tab, Color.White), new Position(3, 5));
                tab.colPiece(new King(tab, Color.White), new Position(5, 5));

                Screen.imprBoard(tab);
            }
            catch (BoardExceptions e)
            {

                Console.WriteLine(e.Message);
            }
            
        }
    }
}
