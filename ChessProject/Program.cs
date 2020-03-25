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
                    try { 
                        Console.Clear();
                        Screen.imprGame(game);

                        Console.WriteLine();
                        Console.Write("Origin:");
                        Position origin = Screen.readPositionChess().toPosition();
                        game.validatePositionOrigin(origin);

                        bool[,] possiblePositions = game.Tab.colPiece(origin).movPossible();

                        Console.Clear();
                        Screen.imprBoard(game.Tab, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destiny:");
                        Position destiny = Screen.readPositionChess().toPosition();
                        game.validatePositionDestini(origin, destiny);

                        game.perform(origin, destiny);
                    }
                    catch (BoardExceptions e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

               
            }
            catch (BoardExceptions e)
            {

                Console.WriteLine(e.Message);
            }
            
        }
    }
}
