using System;
using System.Collections.Generic;
using System.Text;

namespace ChessProject.Board
{
    class Position
    {
        public int line { get; set; }
        public int column { get; set; }

        public Position(int line, int column)
        {
            this.line = line;
            this.column = column;
        }

        //Method ToString
        public override string ToString()
        {
            return line
            +" , "
            + column;
        }
    }
}
