using System;
using System.Collections.Generic;
using System.Text;

namespace ChessProject.board
{
    abstract class Piece // We created an abstract method, the class must be abstract!!!
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QntMov { get; protected set; }

        public Board Board { get; protected set; }

        public Piece( Color color, Board board)
        {
            Position = null;
            Color = color;
            Board = board;
            QntMov = 0;
        }

        //Method to increment the piece moviments
        public void incrementQtdMoviment()
        {
            QntMov++;
        }

        //Method that checks if there is possible movement
        
        public bool ifPossibleMovement()
        {
            bool[,] mat = movPossible();
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }






        //Method that approves the movement of pieces
        public abstract bool[,] movPossible();
    }
}
