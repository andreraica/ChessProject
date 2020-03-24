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


        //method colPiece overload
        public Piece colPiece(Position pos)
        {
            return pieces[pos.Row, pos.Column];
        }

        //method to check if there is peace in the respective place
        public bool existPiece(Position pos)
        {
            validatePosition(pos);
            return colPiece(pos) != null;
        }

        //create a method to insert piece in position
        public void colPiece(Piece p, Position pos)
        {
            if (existPiece(pos))
            {
                throw new BoardExceptions("There is a piece in this position.");
            }
            //matriz
            pieces[pos.Row, pos.Column] = p;  //the piece 'p' will be placed in this matriz pieces
            p.Position = pos;
        }

        //create a method to remove piece
        public Piece removePiece(Position pos)
        {
            if (colPiece(pos) == null)
            {
                return null;
            }
            Piece aux = colPiece(pos);
            aux.Position = null;
            pieces[pos.Row, pos.Column] = null;
            return aux;
        }

        //create a method to check the positions of the board.
        public bool positionVal(Position pos)
        {
            if (pos.Row < 0 || pos.Row >= Rows || pos.Column < 0 || pos.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        //create a method to check the position and throw exception
        public void validatePosition(Position pos)
        {
            if (!positionVal(pos))
            {
                throw new BoardExceptions("Invalidet Position");
            }
        }

    }
}
