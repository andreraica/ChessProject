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
        private HashSet<Piece>pieceM;
        private HashSet<Piece> pieceCap;
        public bool Xeque { get; private set; }


        public GameChess()
        {
            Tab = new Board(8, 8);
            Shift = 1;
            ActualPlayer = Color.White;
            finished = false;
            Xeque = false;
            pieceM = new HashSet<Piece>();
            pieceCap = new HashSet<Piece>();
            putPieces();
            
        }

        public Piece execMoviment(Position origin, Position destiny)
        {
            Piece p = Tab.removePiece(origin);
            p.incrementQtdMoviment();
            Piece pieceCaptured = Tab.removePiece(destiny);
            Tab.colPiece(p, destiny);
            if (pieceCaptured != null)
            {
                pieceCap.Add(pieceCaptured);
            }
            return pieceCaptured;
        }


        //Method to undo moviment
        public void undoMoviment(Position origin, Position destiny, Piece pieceCaptured)
        {
            Piece p = Tab.removePiece(destiny);
            p.decrementQtdMoviment();
            if (pieceCaptured != null)
            {
                Tab.colPiece(pieceCaptured, destiny);
                pieceCap.Remove(pieceCaptured);
            }
            Tab.colPiece(p, origin);


        }


        //Method play restrictions
        public void perform(Position origin, Position destiny)
        {
            Piece pieceCaptured =  execMoviment(origin, destiny);

            if (stayInCheck(ActualPlayer))
            {
                undoMoviment(origin, destiny, pieceCaptured);
                throw new BoardExceptions("You can't put yourself in check!!!");
            }

            if (stayInCheck(adversary(ActualPlayer)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }

            Shift++;
            turnPlayer();
        }

        //Method test if origin position is valid
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

        //Method test if destini position is valid
        public void validatePositionDestini(Position origin, Position destiny)
        {
            if (!Tab.colPiece(origin).canMoveFrom(destiny))
            {
                throw new BoardExceptions("Destini Position is invalid!");
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

        //Method to know captured the same color piece
        public HashSet<Piece>colorPieceCaptured(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieceCap)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        //Method to know captured the same color piece in the game
        public HashSet<Piece> piecesInTheGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieceM)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(colorPieceCaptured(color));
            return aux;
        }


        //method to select the king of each color - checkmate
        private Color adversary(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece king(Color color)
        {
            foreach  (Piece x in piecesInTheGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        //method that tests the king is in check - checkmate
        public bool stayInCheck(Color color)
        {
            Piece R = king(color);
            if (R == null)
            {
                throw new BoardExceptions("Not have a " + color + "king in Boar!");
            }
            foreach (Piece x in piecesInTheGame(adversary(color)))
            {
                bool[,] mat = x.movPossible();
                if (mat [R.Position.Row, R.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }


        //Method put new piece
        public void putNewPiece(char column, int row, Piece piece)
        {
            Tab.colPiece(piece, new PositionChess(column, row).toPosition());
            pieceM.Add(piece);
        }

        private void putPieces() 
        {
            putNewPiece('c', 1, new Tower(Tab, Color.White));
            putNewPiece('c', 2, new Tower(Tab, Color.White));
            putNewPiece('d', 2, new Tower(Tab, Color.White));
            putNewPiece('e', 2, new Tower(Tab, Color.White));
            putNewPiece('e', 1, new Tower(Tab, Color.White));
            putNewPiece('d', 1, new King(Tab, Color.White));


            putNewPiece('c', 7, new Tower(Tab, Color.Black));
            putNewPiece('c', 8, new Tower(Tab, Color.Black));
            putNewPiece('d', 7, new Tower(Tab, Color.Black));
            putNewPiece('e', 7, new Tower(Tab, Color.Black));
            putNewPiece('e', 8, new Tower(Tab, Color.Black));
            putNewPiece('d', 8, new King(Tab, Color.Black));

        }
    }
}
