using System;
using System.Collections.Generic;
using System.Text;
using ChessProject.board;

namespace ChessProject.chess
{
    class Tower : Piece
    {

        public Tower (Board board, Color color) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "T";
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

            //Above
            pos.defineValues(Position.Row - 1, Position.Column);
            while (Board.positionVal(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.colPiece(pos) != null && Board.colPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Row = pos.Row - 1;
            }


            //Below
            pos.defineValues(Position.Row + 1, Position.Column);
            while (Board.positionVal(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.colPiece(pos) != null && Board.colPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Row = pos.Row + 1;
            }

            //Right
            pos.defineValues(Position.Row, Position.Column +1);
            while (Board.positionVal(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.colPiece(pos) != null && Board.colPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }

            //Left
            pos.defineValues(Position.Row, Position.Column - 1);
            while (Board.positionVal(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.colPiece(pos) != null && Board.colPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }


            return mat;
        }
    }
}
