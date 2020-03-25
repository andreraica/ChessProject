using System;
using System.Collections.Generic;
using System.Text;
using ChessProject.board;

namespace ChessProject.chess
{
    class GameChess
    {
        public Board Tab { get; private set; }
        public int Shift { get; private set; }
        public Color ActualPlayer { get; private set; }
        public bool finished { get; private set; }


        public GameChess()
        {
            Tab = new Board(8, 8);
            Shift = 1;
            ActualPlayer = Color.White;
            finished = false;
            putPieces();
            
        }

        public void execMoviment(Position origin, Position destiny)
        {
            Piece p = Tab.removePiece(origin);
            p.incrementQtdMoviment();
            Piece pieceCaptured = Tab.removePiece(destiny);
            Tab.colPiece(p, destiny);
        }


        //Method play restrictions
        public void perform(Position origin, Position destiny)
        {
            execMoviment(origin, destiny);
            Shift++;
            turnPlayer();
        }

        //Method test if position is valid
        public void validatePositionOrigin(Position pos)
        {
            if (Tab.colPiece(pos) == null)
            {
                throw new BoardExceptions("There is no piece in the chosen position of origin.");
            }
            if (ActualPlayer != Tab.colPiece(pos).Color)
            {
                throw new BoardExceptions("The original piece chosen is not yours!");
            }
            if (!Tab.colPiece(pos).ifPossibleMovement())
            {
                throw new BoardExceptions("There are no possible movements for the original piece chosen.");
            }
        }

        public void turnPlayer()
        {
            if (ActualPlayer == Color.White)
            {
                ActualPlayer = Color.Black;
            }
            else
            {
                ActualPlayer = Color.White;
            }
        }

        private void putPieces() 
        {
            Tab.colPiece(new Tower(Tab, Color.White), new PositionChess('c', 1).toPosition());
            Tab.colPiece(new Tower(Tab, Color.White), new PositionChess('c', 2).toPosition());
            Tab.colPiece(new Tower(Tab, Color.White), new PositionChess('d', 2).toPosition());
            Tab.colPiece(new King(Tab, Color.White), new PositionChess('d', 1).toPosition());
            Tab.colPiece(new King(Tab, Color.White), new PositionChess('e', 1).toPosition());
            Tab.colPiece(new King(Tab, Color.White), new PositionChess('e', 2).toPosition());


            Tab.colPiece(new Tower(Tab, Color.Black), new PositionChess('c', 7).toPosition());
            Tab.colPiece(new Tower(Tab, Color.Black), new PositionChess('c', 8).toPosition());
            Tab.colPiece(new Tower(Tab, Color.Black), new PositionChess('d', 7).toPosition());
            Tab.colPiece(new King(Tab, Color.Black), new PositionChess('d', 8).toPosition());
            Tab.colPiece(new King(Tab, Color.Black), new PositionChess('h', 8).toPosition());

        }
    }
}
