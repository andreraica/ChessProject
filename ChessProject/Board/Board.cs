using System;
using System.Collections.Generic;
using System.Text;

namespace ChessProject.board
{
    class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        private Piece[,] pieces;

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            pieces = new Piece[rows, columns];
        }

        //create a method to access the matriz, because its private
        public Piece piece (int row, int column)
        {
            return pieces[row, column];
        }
    }
}
