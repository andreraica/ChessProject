using System;
using System.Collections.Generic;
using System.Text;
using ChessProject.board;

namespace ChessProject.chess
{
    class Horse : Piece
    {
        public Horse(Board board, Color color) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "C";
        }


        //METHOD TO CHECK IF YOU CAN MOVE THE PIECE
        private bool canMove(Position pos)
        {
            Piece p = Board.colPiece(pos);
            return p == null || p.Color != Color;
        }

        //Method to check the possible move from king
        public override bool[,] movPossible()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            pos.defineValues(Position.Row - 1, Position.Column - 2);
            if (Board.positionVal(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.defineValues(Position.Row - 2, Position.Column - 1);
            if (Board.positionVal(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.defineValues(Position.Row - 2, Position.Column + 1);
            if (Board.positionVal(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.defineValues(Position.Row - 1, Position.Column + 2);
            if (Board.positionVal(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.defineValues(Position.Row + 1, Position.Column + 2);
            if (Board.positionVal(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.defineValues(Position.Row + 2, Position.Column + 1);
            if (Board.positionVal(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.defineValues(Position.Row + 2, Position.Column -1);
            if (Board.positionVal(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.defineValues(Position.Row + 1, Position.Column - 2);
            if (Board.positionVal(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }


            return mat;

        }

    }
}
