using System;
using System.Collections.Generic;
using System.Text;
using ChessProject.board;

namespace ChessProject
{
    class Screen
    {
        public static void imprBoard(Board tab) {

            for (int i = 0; i < tab.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Columns; j++)
                {
                    
                    if (tab.piece(i, j) == null)
                    {
                       
                        Console.Write("- ");
                    }
                    else
                    {
                        printPiace(tab.piece(i, j));
                        Console.Write(" ");
                    }
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        //create method to change the color of piece
        public static void printPiace(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor x = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = x;
            }
        }

    }
}
