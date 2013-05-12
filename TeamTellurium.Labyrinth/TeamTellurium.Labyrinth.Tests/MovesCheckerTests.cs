using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamTellurium.Labyrinth.Tests
{
    [TestClass]
    public class MovesCheckerTests
    {
        [TestMethod]
        public void TestIsValidMove_RightDirection()
        {
            int[,] labyrinthGrid = new int[7, 7]
                        {
                            {0, 0, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1},
                            {0, 0, 0, 0, 0, 0, 0},
                            {1, 0, 1, 0, 0, 1, 1},
                            {0, 1, 0, 1, 0, 0, 0},
                            {0, 0, 1, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0}
                        };

            Playfield playfield = new Playfield();
            playfield.InitializeField();
            playfield.LabyrinthGrid = labyrinthGrid;
            Direction directionRight = Direction.Right;

            bool expected = true;
            bool actual = MovesChecker.IsValidMove(playfield, Direction.Right);
            Assert.AreEqual(expected, actual);
        }
    }
}
