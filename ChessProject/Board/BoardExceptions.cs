using System;
using System.Collections.Generic;
using System.Text;

namespace ChessProject.board
{
    class BoardExceptions : Exception
    {
        public BoardExceptions (string msg) : base(msg)
        {

        }
    }
}
