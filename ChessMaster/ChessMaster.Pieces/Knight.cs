﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChessMaster.Pieces
{
    public class Knight : BasePiece
    {
        public Knight(int x, int y, bool isWhite = true) : base(x, y, isWhite)
        {
            if (IsWhite)
            {
                PieceImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Images/white_knight.png");
            }
            else
            {
                PieceImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Images/black_knight.png");
            }
        }
        public Knight(bool isWhite = true) : base(isWhite)
        {
            if (IsWhite)
            {
                PieceImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Images/white_knight.png");
            }
            else
            {
                PieceImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Images/black_knight.png");
            }
        }
        public override List<PiecePossibleMove> GetPossibleMoves(List<BasePiece> board)
        {
            return base.GetKnightMoves(board);
        }

        public override BasePiece CopyPiece()
        {
            return new Knight((int)Position.X, (int)Position.Y, IsWhite)
            {
                IsFirstMove = IsFirstMove
            };
        }
    }
}
