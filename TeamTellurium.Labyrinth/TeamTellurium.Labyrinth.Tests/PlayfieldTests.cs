using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamTellurium.Labyrinth.Tests
{
    [TestClass]
    public class PlayfieldTests
    {
        [TestMethod]
        public void TestPlayfield_CustomLabyrinthRowsColsInRange()
        {
            int[,] labyrinthGrid = new int[7, 7];

            Playfield playfield = new Playfield(labyrinthGrid);
            Assert.AreSame(playfield.LabyrinthGrid, labyrinthGrid);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestPlayfield_CustomLabyrinthLessRows()
        {
            int[,] labyrinthGrid = new int[4, 7];

            Playfield playfield = new Playfield(labyrinthGrid);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestPlayfield_CustomLabyrinthMoreRows()
        {
            int[,] labyrinthGrid = new int[8, 7];

            Playfield playfield = new Playfield(labyrinthGrid);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestPlayfield_CustomLabyrinthLessCols()
        {
            int[,] labyrinthGrid = new int[8, 3];

            Playfield playfield = new Playfield(labyrinthGrid);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestPlayfield_CustomLabyrinthMoreCols()
        {
            int[,] labyrinthGrid = new int[7, 8];

            Playfield playfield = new Playfield(labyrinthGrid);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestPlayfield_CustomLabyrinthMoreRowsAndCols()
        {
            int[,] labyrinthGrid = new int[12, 8];

            Playfield playfield = new Playfield(labyrinthGrid);
        }

        [TestMethod]
        public void TestIsVictory_EastEndExit()
        {
            int[,] labyrinthGrid = new int[7, 7]
                        {
                            {0, 0, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1},
                            {0, 0, 0, 0, 0, 0, 0},
                            {1, 0, 1, 0, 0, 0, 0},
                            {0, 1, 0, 1, 0, 0, 0},
                            {0, 0, 1, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0}
                        };

            Playfield playfield = new Playfield(labyrinthGrid);
            playfield.PlayerPosition.MoveAtDirection(Direction.Right);
            playfield.PlayerPosition.MoveAtDirection(Direction.Right);
            playfield.PlayerPosition.MoveAtDirection(Direction.Right);
            
            bool expected = true;
            bool actual = playfield.IsVictory();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsVictory_WestEndExit()
        {
            int[,] labyrinthGrid = new int[7, 7]
                        {
                            {0, 0, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1},
                            {0, 0, 0, 0, 1, 0, 0},
                            {0, 0, 0, 0, 1, 0, 1},
                            {0, 1, 0, 1, 0, 0, 0},
                            {0, 0, 1, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0}
                        };

            Playfield playfield = new Playfield(labyrinthGrid);
            playfield.PlayerPosition.MoveAtDirection(Direction.Left);
            playfield.PlayerPosition.MoveAtDirection(Direction.Left);
            playfield.PlayerPosition.MoveAtDirection(Direction.Left);

            bool expected = true;
            bool actual = playfield.IsVictory();
            Assert.AreEqual(expected, actual);
        }

    }
}
