using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamTellurium.Labyrinth.Tests
{
    [TestClass]
    public class PositionTests
    {
        /// <summary>
        /// When position.Row = 0, then this means that player has escaped
        /// from the left side of the labyrinth and is winner.
        /// </summary>
        [TestMethod]
        public void TestIsWinner_WhenRowEqualsZero()
        {
            Position position = new Position();
            position.Row = 0;

            Assert.IsTrue(position.IsWinner());
        }

        [TestMethod]
        public void TestIsWinner_WhenRowEqualsThree()
        {
            Position position = new Position();
            position.Row = 3;

            Assert.IsFalse(position.IsWinner());
        }

        [TestMethod]
        public void TestIsWinner_WhenRowEqualsFive()
        {
            Position position = new Position();
            position.Row = 5;

            Assert.IsFalse(position.IsWinner());
        }

        /// <summary>
        /// When position.Row = 6, then this means that player has escaped
        /// from the rigth side of the labyrinth and is winner.
        /// </summary>
        [TestMethod]
        public void TestIsWinner_WhenRowEqualsSix()
        {
            Position position = new Position();
            position.Row = 6;

            Assert.IsTrue(position.IsWinner());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]     
        public void TestIsWinner_OutOfBoundsRowEqualsMinusOne()
        {
            Position position = new Position();
            position.Row = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIsWinner_OutOfBoundsRowEqualsSeven()
        {
            Position position = new Position();
            position.Row = 7;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIsWinner_OutOfBoundsColEqualsMinusOne()
        {
            Position position = new Position();
            position.Col = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIsWinner_OutOfBoundsColEqualSeven()
        {
            Position position = new Position();
            position.Col = 7;
        }

        /// <summary>
        /// When position.Col = 0, then this means that player has escaped
        /// from the top side of the labyrinth and is winner.
        /// </summary>
        [TestMethod]
        public void TestIsWinner_WhenColEqualsZero()
        {
            Position position = new Position();
            position.Col = 0;

            Assert.IsTrue(position.IsWinner());
        }

        [TestMethod]
        public void TestIsWinner_WhenColEqualsThree()
        {
            Position position = new Position();
            position.Col = 3;

            Assert.IsFalse(position.IsWinner());
        }

        [TestMethod]
        public void TestIsWinner_WhenColEqualsFive()
        {
            Position position = new Position();
            position.Col = 5;

            Assert.IsFalse(position.IsWinner());
        }

        /// <summary>
        /// When position.Col = 6, then this means that player has escaped
        /// from the bottom side of the labyrinth and is winner.
        /// </summary>
        [TestMethod]
        public void TestIsWinner_WhenColEqualsSix()
        {
            Position position = new Position();
            position.Col = 6;

            Assert.IsTrue(position.IsWinner());
        }

        [TestMethod]
        public void TestSetStartPosition()
        {
            Position initialPosition = new Position();
            initialPosition.SetStartPosition();
            bool initialPositionCoordinates = (initialPosition.Row == 3 && initialPosition.Col == 3);

            Assert.IsTrue(initialPositionCoordinates);
        }

        [TestMethod]
        public void TestMoveAtDirection_Right()
        {
            Position expectedPosition = new Position(3, 4);
            Position actualPosition = new Position(3, 3);
            actualPosition.MoveAtDirection(Direction.Right);

            Assert.AreEqual(expectedPosition.Row, actualPosition.Row);
        }

        [TestMethod]
        public void TestMoveAtDirection_Left()
        {
            Position expectedPosition = new Position(3, 2);
            Position actualPosition = new Position(3, 3);
            actualPosition.MoveAtDirection(Direction.Left);

            Assert.AreEqual(expectedPosition.Row, actualPosition.Row);
        }

        [TestMethod]
        public void TestMoveAtDirection_Up()
        {
            Position expectedPosition = new Position(3, 2);
            Position actualPosition = new Position(4, 3);
            actualPosition.MoveAtDirection(Direction.Up);

            Assert.AreEqual(expectedPosition.Row, actualPosition.Row);
        }

        [TestMethod]
        public void TestMoveAtDirection_Down()
        {
            Position expectedPosition = new Position(5, 2);
            Position actualPosition = new Position(4, 3);
            actualPosition.MoveAtDirection(Direction.Down);

            Assert.AreEqual(expectedPosition.Row, actualPosition.Row);
        }
    }
}