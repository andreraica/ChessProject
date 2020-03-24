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
                GameChess game = new GameChess();
                Screen.imprBoard(game.Tab);
            }
            catch (BoardExceptions e)
            {

                Console.WriteLine(e.Message);
            }
            
        }
    }
}
