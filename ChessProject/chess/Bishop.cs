using System;
using System.Collections.Generic;
using System.Text;
using ChessProject.board;

namespace ChessProject.chess
{
    class Bishop : Piece
    {

        public Bishop(Board board, Color color) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "B";
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


            //NO
            pos.defineValues(Position.Row - 1, Position.Column -1);
            while (Board.positionVal(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.colPiece(pos) != null && Board.colPiece(pos).Color != Color)
                {
                    break;
                }
                pos.defineValues(pos.Row - 1, pos.Column - 1);
            }

            //ME
            pos.defineValues(Position.Row - 1, Position.Column + 1);
            while (Board.positionVal(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.colPiece(pos) != null && Board.colPiece(pos).Color != Color)
                {
                    break;
                }
                pos.defineValues(pos.Row - 1, pos.Column + 1);
            }

            //SE
            pos.defineValues(Position.Row + 1, Position.Column + 1);
            while (Board.positionVal(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.colPiece(pos) != null && Board.colPiece(pos).Color != Color)
                {
                    break;
                }
                pos.defineValues(pos.Row + 1, pos.Column + 1);
            }

            //S0
            pos.defineValues(Position.Row + 1, Position.Column - 1);
            while (Board.positionVal(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.colPiece(pos) != null && Board.colPiece(pos).Color != Color)
                {
                    break;
                }
                pos.defineValues(pos.Row + 1, pos.Column - 1);
            }

            return mat;
        }

    }
}
