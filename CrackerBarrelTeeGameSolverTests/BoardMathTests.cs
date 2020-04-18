using CrackerBarrelTeeGameSolver;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class BoardMathTest
    {
        [TestCase(0, 0, false)]
        [TestCase(0, 1, false)]
        [TestCase(1, 0, false)]
        [TestCase(1, 1, true)]
        [TestCase(2, 0, false)]
        [TestCase(2, 1, true)]
        [TestCase(2, 2, true)]
        [TestCase(2, 3, false)]
        [TestCase(5, 0, false)]
        [TestCase(5, 1, true)]
        [TestCase(5, 2, true)]
        [TestCase(5, 5, true)]
        [TestCase(5, 6, false)]
        [TestCase(6, 3, false)]
        public void AreLegalCoordinatesTest(int row, int column, bool result)
        {
            BoardMath.AreLegalCoordinates(row, column).Should().Be(result);
        }

        [TestCase(1, 1, 1)]
        [TestCase(2, 1, 2)]
        [TestCase(2, 2, 3)]
        [TestCase(3, 1, 4)]
        [TestCase(3, 2, 5)]
        [TestCase(3, 3, 6)]
        [TestCase(4, 1, 7)]
        [TestCase(4, 2, 8)]
        [TestCase(4, 3, 9)]
        [TestCase(4, 4, 10)]
        [TestCase(5, 1, 11)]
        [TestCase(5, 2, 12)]
        [TestCase(5, 3, 13)]
        [TestCase(5, 4, 14)]
        [TestCase(5, 5, 15)]
        public void GetPositionsForCoordinatesTest(int row, int column, int expectedPosition)
        {
            BoardMath.GetPositionForCoordinates(row, column).Should().Be(expectedPosition);
        }

        [TestCase(1, 1, 1)]
        [TestCase(2, 2, 1)]
        [TestCase(3, 2, 2)]
        [TestCase(4, 3, 1)]
        [TestCase(5, 3, 2)]
        [TestCase(6, 3, 3)]
        [TestCase(7, 4, 1)]
        [TestCase(8, 4, 2)]
        [TestCase(9, 4, 3)]
        [TestCase(10, 4, 4)]
        [TestCase(11, 5, 1)]
        [TestCase(12, 5, 2)]
        [TestCase(13, 5, 3)]
        [TestCase(14, 5, 4)]
        [TestCase(15, 5, 5)]
        public void GetCoordinatesForPositionTest(int position, int expectedRow, int expectedColumn)
        {
            BoardMath.GetCoordinatesForPosition(position).Item1.Should().Be(expectedRow);
            BoardMath.GetCoordinatesForPosition(position).Item2.Should().Be(expectedColumn);
        }
    }
}