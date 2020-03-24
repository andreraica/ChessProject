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
                for (int j = 0; j < tab.Columns; j++)
                {
                    if (tab.piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.piece(i, j) + " ");
                    }
                    
                }
                Console.WriteLine();
            }
        }

    }
}
