using System;
using System.Collections.Generic;
using System.Text;
using ChessProject.board;

namespace ChessProject.chess
{
    class PositionChess
    {
        public char Column { get; set; }
        public int Row { get; set; }

        public PositionChess(char column, int row)
        {
            Column = column;
            Row = row;
        }

        //convert the normal position of the game to the position in the project matriz
        public Position toPosition()
        {
            return new Position(8 - Row, Column - 'a');
        }
        public override string ToString()
        {
            return "" + Column + Row;
        }
    }
}
