using System;
using System.Collections.Generic;
using System.Text;
using ChessProject.board;

namespace ChessProject.chess
{
    class Peao : Piece
    {
        private GameChess GameX;
        public Peao(Board board, Color color, GameChess gameX) : base(color, board)
        {
            GameX = gameX;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool existInim(Position pos)
        {
            Piece p = Board.colPiece(pos);
            return p != null && p.Color != Color;
        }

        private bool free (Position pos)
        {
            return Board.colPiece(pos) == null;
        }

        //Method to check the possible move from king
        public override bool[,] movPossible()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.defineValues(Position.Row - 1, Position.Column);
                if (Board.positionVal(pos) && free(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.defineValues(Position.Row - 2, Position.Column);
                if (Board.positionVal(pos) && free(pos) && QntMov == 0)
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.defineValues(Position.Row - 1, Position.Column -1);
                if (Board.positionVal(pos) && existInim(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.defineValues(Position.Row - 1, Position.Column + 1);
                if (Board.positionVal(pos) && existInim(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                //#Special game en passant
                if (Position.Row == 3)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.positionVal(left) && existInim(left) && Board.colPiece(left) == GameX.VulnEnPassant)
                    {
                        mat[left.Row -1, left.Column] = true;
                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.positionVal(right) && existInim(right) && Board.colPiece(right) == GameX.VulnEnPassant)
                    {
                        mat[right.Row -1, right.Column] = true;
                    }
                }
            }
            else
            {
                pos.defineValues(Position.Row + 1, Position.Column);
                if (Board.positionVal(pos) && free(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.defineValues(Position.Row + 2, Position.Column);
                if (Board.positionVal(pos) && free(pos) && QntMov == 0)
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.defineValues(Position.Row + 1, Position.Column - 1);
                if (Board.positionVal(pos) && existInim(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.defineValues(Position.Row + 1, Position.Column + 1);
                if (Board.positionVal(pos) && existInim(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                //#Special game en passant
                if (Position.Row == 4)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.positionVal(left) && existInim(left) && Board.colPiece(left) == GameX.VulnEnPassant)
                    {
                        mat[left.Row +1, left.Column] = true;
                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.positionVal(right) && existInim(right) && Board.colPiece(right) == GameX.VulnEnPassant)
                    {
                        mat[right.Row +1, right.Column] = true;
                    }
                }
            }
            return mat;
        }

    }   
 
}
