using System;
using System.Collections.Generic;
using System.Text;

namespace ChessProject.board
{
    class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        //Method to define values
        public void defineValues(int row , int column)
        {
            Row = row;
            Column = column;
        }

        //Method ToString
        public override string ToString()
        {
            return Row
            +" , "
            + Column;
        }
    }
}
