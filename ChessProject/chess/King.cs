using System;
using System.Collections.Generic;
using System.Text;
using ChessProject.board;

namespace ChessProject.chess
{
    class King : Piece
    {
        private GameChess GameX;

        public King(Board board, Color color, GameChess gameX) : base(color, board)
        {
            GameX = gameX;
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

        //Method to roque small
        private bool testTowerFromRoque(Position pos)
        {
            Piece p = Board.colPiece(pos);
            return p != null && p is Tower && p.Color == Color && p.QntMov == 0;
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


            //#Special game ROCK
            if (QntMov == 0 && !GameX.Xeque)
            {
                //#Special game roque small
                Position posT1 = new Position(Position.Row, Position.Column +3);
                if (testTowerFromRoque(posT1))
                {
                    Position P1 = new Position(Position.Row, Position.Column + 1);
                    Position P2 = new Position(Position.Row, Position.Column + 2);
                    if (Board.colPiece(P1) == null && Board.colPiece(P2) == null)
                    {
                        mat[Position.Row, Position.Column + 2] = true;
                    }
                }
                //#Special game roque big
                Position posT2 = new Position(Position.Row, Position.Column -4);
                if (testTowerFromRoque(posT2))
                {
                    Position P1 = new Position(Position.Row, Position.Column - 1);
                    Position P2 = new Position(Position.Row, Position.Column - 2);
                    Position P3 = new Position(Position.Row, Position.Column - 3);
                    if (Board.colPiece(P1) == null && Board.colPiece(P2) == null && Board.colPiece(P3) == null)
                    {
                        mat[Position.Row, Position.Column - 2] = true;
                    }
                }
            }


            return mat;
        }
    }
}
