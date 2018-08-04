using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessMaster;
using ChessMaster.ViewModel;
using ChessMaster.Pieces;
using System.Collections.Generic;

namespace ChessTest
{
    [TestClass]
    public class Chess960Tester
    {
        [TestMethod]
        public void KingIsInBetweenRooks()
        {
            ChessBoard chessBoard = new ChessBoard(false);
            List<ChessCell> blackPieces = GetBlackPiecePlacement(chessBoard.Board);
            int kingIndex = GetPieceIndex(blackPieces, typeof(King));
            int RookOneIndex = GetPieceIndex(blackPieces, typeof(Rook));
            int RookTwoIndex = GetPieceIndex(blackPieces, typeof(Rook), true);
            bool expected = true;
            bool actual = (RookOneIndex < kingIndex) && (RookTwoIndex > kingIndex);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void KingIsNotOnEdges()
        {
            ChessBoard chessBoard = new ChessBoard(false);
            List<ChessCell> blackPieces = GetBlackPiecePlacement(chessBoard.Board);
            int kingIndex = GetPieceIndex(blackPieces, typeof(King));
            bool expected = true;
            bool actual = (kingIndex != 0) && (kingIndex != blackPieces.Count - 1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BishopsAreOnDifferentColors()
        {
            ChessBoard chessBoard = new ChessBoard(false);
            List<ChessCell> blackPieces = GetBlackPiecePlacement(chessBoard.Board);
            int bishopOneIndex = GetPieceIndex(blackPieces, typeof(Bishop));
            int bishopTwoIndex = GetPieceIndex(blackPieces, typeof(Bishop), true);
            bool bishopOneOnBlack = bishopOneIndex % 2 == 0;
            bool bishopTwoOnBlack = bishopTwoIndex % 2 == 0;
            bool expected = true;
            bool actual = bishopOneIndex != bishopTwoIndex;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void BlackAndWhitePiecesMirrorEachOther()
        {
            ChessBoard chessBoard = new ChessBoard(false);
            List<ChessCell> blackPieces = GetBlackPiecePlacement(chessBoard.Board);
            List<ChessCell> whitePieces = GetWhitePiecePlacement(chessBoard.Board);
            bool actual = true;
            bool expected = true;
            for(int i = 0; i < whitePieces.Count; i++)
            {
                if(whitePieces[i].GetType() != blackPieces[i].GetType())
                {
                    actual = !actual;
                }
            }
            Assert.AreEqual(expected, actual);
        }
        private List<ChessCell> GetBlackPiecePlacement(List<ChessCell> list)
        {
            List<ChessCell> result = new List<ChessCell>();
            for(int i = 0; i < 8; i++)
            {
                result.Add(list[i]);
            }
            return result;
        }

        private List<ChessCell> GetWhitePiecePlacement(List<ChessCell> list)
        {
            List<ChessCell> result = new List<ChessCell>();
            for (int i = 56; i < list.Count; i++)
            {
                result.Add(list[i]);
            }
            return result;
        }

        private int GetPieceIndex(List<ChessCell> cells, Type pieceType, bool findSecond = false)
        {
            int result = 0;
            bool foundFirst = false;
            foreach(var cell in cells)
            {
                if (findSecond)
                {
                    if (cell.Piece.GetType().Equals(pieceType) && !foundFirst)
                    {
                        foundFirst = !foundFirst;
                    }
                    else if (cell.Piece.GetType().Equals(pieceType) && foundFirst)
                    {
                        result = (int)cell.Piece.Position.X;
                        break;
                    }
                }
                else
                {
                    if (cell.Piece.GetType().Equals(pieceType))
                    {

                        result = (int)cell.Piece.Position.X;
                        break;
                    }
                }
            }
            return result;
        }
    }
}
