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

        //create a method to insert piece in position
        public void colPiece(Piece p, Position pos)
        {
            //matriz
            pieces[pos.Row, pos.Column] = p;  //the piece 'p' will be placed in this matriz pieces
            p.Position = pos;
        }
    }
}
