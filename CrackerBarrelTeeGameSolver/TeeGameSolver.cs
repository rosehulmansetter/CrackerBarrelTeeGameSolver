using System;
using System.Collections.Generic;
using System.IO;

namespace CrackerBarrelTeeGameSolver
{
    public class TeeGameSolver
    {
        private StreamWriter Writer;
        private int totalSolutions = 0;

        internal void Solve()
        {
            Writer = new StreamWriter("Results.txt");
            List<int> startingEmptySpots = new List<int> { 11, 12, 13, 14, 9 };

            foreach(int startingEmptySpot in startingEmptySpots)
            {
                Writer.WriteLine($"Solving for initial empty position {startingEmptySpot}\n");
                totalSolutions = 0;
                Solve(new Board(startingEmptySpot));
                Writer.WriteLine($"Total solutions from position {startingEmptySpot}: {totalSolutions}\n");
            }
            Writer.Flush();
        }

        private void Solve(Board board)
        {
            if(board.NumberOfPegsRemaining() == 1)
            {
                totalSolutions++;
                PrintOutMoves(board);
            }
            else
            {
                List<Move> possibleMoves = board.GetPossibleMoves();
                if (possibleMoves.Count > 0)
                {
                    foreach(Move move in possibleMoves)
                    {
                        var newBoard = new Board(board);
                        newBoard.ApplyMove(move);
                        if (newBoard.NumberOfPegsRemaining() >= board.NumberOfPegsRemaining())
                            throw new Exception();
                        Solve(newBoard);
                    }
                }
            }
        }

        private void PrintOutMoves(Board board)
        {
            foreach(Move move in board.GetMoves())
            {
                Writer.WriteLine($"Moved peg in position {move.JumpingPeg} over peg in position {move.JumpedPeg} to space in position {move.NewPosition}");
            }
            Writer.WriteLine();
        }
    }
}
