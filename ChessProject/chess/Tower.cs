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
    }
}
