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

                while (!game.finished)
                {
                    Console.Clear();
                    Screen.imprBoard(game.Tab);

                    Console.WriteLine();
                    Console.Write("Origin:");
                    Position origin = Screen.readPositionChess().toPosition();

                    bool[,] possiblePositions = game.Tab.colPiece(origin).movPossible();

                    Console.Clear();
                    Screen.imprBoard(game.Tab, possiblePositions);

                    Console.Write("Destiny:");
                    Position destiny = Screen.readPositionChess().toPosition();

                    game.execMoviment(origin, destiny);
                }

               
            }
            catch (BoardExceptions e)
            {

                Console.WriteLine(e.Message);
            }
            
        }
    }
}
