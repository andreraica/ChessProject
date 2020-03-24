using System;
using System.Collections.Generic;
using System.Text;
using ChessProject.board;
using ChessProject.chess;

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

        //create a method to read the position input
        public static PositionChess readPositionChess()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row =int.Parse( s[1] + "");
            return new PositionChess(column, row);
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
