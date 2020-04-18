using System;

namespace CrackerBarrelTeeGameSolver
{
    public static class BoardMath
    {
        public static bool AreLegalCoordinates(int row, int column)
        {
            return row <= 5 && row >= 1 && column >= 1 && column <= row;
        }

        public static int GetPositionForCoordinates(int offsetRow, int offsetColumn)
        {
            return TotalPegsInFirstNRows(offsetRow - 1) + offsetColumn;
        }

        public static Tuple<int, int> GetCoordinatesForPosition(int position)
        {
            int row = 1;

            while (position > TotalPegsInFirstNRows(row))
            {
                row++;
            }

            int column = position - TotalPegsInFirstNRows(row - 1);

            return new Tuple<int, int>(row, column);
        }

        private static int TotalPegsInFirstNRows(int numRows)
        {
            return numRows * (numRows + 1) / 2;
        }

    }
}
