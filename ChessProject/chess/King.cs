using System;
using System.Collections.Generic;
using System.Text;
using ChessProject.board;

namespace ChessProject.chess
{
    class King : Piece
    {
        public King(Board board, Color color) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "K";
        }


        //METHOD TO CHECK IF YOU CAN MOVE THE PIECE
        private bool canMove (Position pos)
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
            if (Board.positionVal(pos) &&  canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //NDE
            pos.defineValues(Position.Row - 1, Position.Column +1);
            if (Board.positionVal(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }


            //Right
            pos.defineValues(Position.Row, Position.Column + 1);
            if (Board.positionVal(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //SDE
            pos.defineValues(Position.Row +1, Position.Column + 1);
            if (Board.positionVal(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Below
            pos.defineValues(Position.Row + 1, Position.Column);
            if (Board.positionVal(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //SUD
            pos.defineValues(Position.Row + 1, Position.Column -1);
            if (Board.positionVal(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Left
            pos.defineValues(Position.Row, Position.Column - 1);
            if (Board.positionVal(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //NOR
            pos.defineValues(Position.Row -1, Position.Column - 1);
            if (Board.positionVal(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            return mat;
        }
    }
}
