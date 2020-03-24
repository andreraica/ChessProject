using System;
using System.Collections.Generic;
using System.Text;
using ChessProject.board;

namespace ChessProject.chess
{
    class GameChess
    {
        public Board Tab { get; private set; }
        private int Shift;
        private Color ActualPlayer;


        public GameChess()
        {
            Tab = new Board(8, 8);
            Shift = 1;
            ActualPlayer = Color.White;
            putPieces(); 
        }

        public void execMoviment(Position origin, Position destiny)
        {
            Piece p = Tab.removePiece(origin);
            p.incrementQtdMoviment();
            Piece pieceCaptured = Tab.removePiece(destiny);
            Tab.colPiece(p, destiny);
        }

        private void putPieces() 
        {
            Tab.colPiece(new Tower(Tab, Color.White), new PositionChess('c', 1).toPosition());
            Tab.colPiece(new Tower(Tab, Color.White), new PositionChess('c', 2).toPosition());
            Tab.colPiece(new Tower(Tab, Color.White), new PositionChess('d', 2).toPosition());
            Tab.colPiece(new King(Tab, Color.White), new PositionChess('d', 1).toPosition());


            Tab.colPiece(new Tower(Tab, Color.Black), new PositionChess('c', 7).toPosition());
            Tab.colPiece(new Tower(Tab, Color.Black), new PositionChess('c', 8).toPosition());
            Tab.colPiece(new Tower(Tab, Color.Black), new PositionChess('d', 7).toPosition());
            Tab.colPiece(new King(Tab, Color.Black), new PositionChess('d', 8).toPosition());
            Tab.colPiece(new King(Tab, Color.Black), new PositionChess('h', 8).toPosition());

        }
    }
}
