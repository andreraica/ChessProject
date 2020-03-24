using System;
using System.Collections.Generic;
using System.Text;

namespace ChessProject.board
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QntMov { get; protected set; }

        public Board Board { get; protected set; }

        public Piece(Position position, Color color, Board board)
        {
            Position = position;
            Color = color;
            Board = board;
            QntMov = 0;
        }
    }
}
