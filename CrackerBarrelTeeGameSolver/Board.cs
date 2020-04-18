using System;
using System.Collections.Generic;

namespace CrackerBarrelTeeGameSolver
{
    internal class Board
    {
        private List<int> pegsRemaining = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        private List<Move> moves = new List<Move>();
        private readonly List<Tuple<int, int>> offsets = new List<Tuple<int, int>> {
                    new Tuple<int, int>(-1, -1),
                    new Tuple<int, int>(-1, 0),
                    new Tuple<int, int>(0, -1),
                    new Tuple<int, int>(0, 1),
                    new Tuple<int, int>(1, 0),
                    new Tuple<int, int>(1, 1),
                };


        public Board(int startingEmptySpot)
        {
            pegsRemaining.Remove(startingEmptySpot);
        }

        public Board(Board other)
        {
            pegsRemaining = new List<int>();
            pegsRemaining.AddRange(other.pegsRemaining);

            moves = new List<Move>();
            moves.AddRange(other.moves);
        }

        internal void ApplyMove(Move move)
        {
            int pegCount = pegsRemaining.Count;
            pegsRemaining.Remove(move.JumpingPeg);
            pegsRemaining.Remove(move.JumpedPeg);
            pegsRemaining.Add(move.NewPosition);

            if (pegsRemaining.Count >= pegCount)
                throw new Exception();
            moves.Add(move);
        }

        internal int NumberOfPegsRemaining()
        {
            return pegsRemaining.Count;
        }

        internal List<Move> GetMoves()
        {
            return moves;
        }

        internal List<Move> GetPossibleMoves()
        {
            List<Move> possibleMoves = new List<Move>();

            foreach (int peg in pegsRemaining)
            {
                List<int> surroundingPositions = new List<int>();

                Tuple<int, int> coordinates = BoardMath.GetCoordinatesForPosition(peg);
                foreach (Tuple<int, int> offset in offsets)
                {
                    Move m = new Move
                    {
                        JumpingPeg = peg
                    };

                    int offsetRow = coordinates.Item1 + offset.Item1;
                    int offsetColumn = coordinates.Item2 + offset.Item2;
                    int offsetPosition = BoardMath.GetPositionForCoordinates(offsetRow, offsetColumn);

                    if (BoardMath.AreLegalCoordinates(offsetRow, offsetColumn) && 
                        pegsRemaining.Contains(offsetPosition))
                    {
                        m.JumpedPeg = offsetPosition;

                        int jumpingToRow = offsetRow + offset.Item1;
                        int jumpingToColumn = offsetColumn + offset.Item2;
                        int jumpingToPosition = BoardMath.GetPositionForCoordinates(jumpingToRow, jumpingToColumn);

                        if(BoardMath.AreLegalCoordinates(jumpingToRow, jumpingToColumn) &&
                            !pegsRemaining.Contains(jumpingToPosition))
                        {
                            m.NewPosition = jumpingToPosition;
                            possibleMoves.Add(m);
                        }
                    }
                }
            }

            return possibleMoves;
        }
    }
}