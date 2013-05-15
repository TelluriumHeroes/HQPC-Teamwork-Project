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

            Position customPosition = new Position(3, 6);
            Playfield playfield = new Playfield(labyrinthGrid, customPosition);
            
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

            Position customPosition = new Position(3, 0);
            Playfield playfield = new Playfield(labyrinthGrid, customPosition);

            bool expected = true;
            bool actual = playfield.IsVictory();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsVictory_NorthEndExit()
        {
            int[,] labyrinthGrid = new int[7, 7]
                        {
                            {0, 0, 1, 0, 1, 1, 1},
                            {1, 1, 1, 0, 1, 1, 1},
                            {0, 0, 0, 0, 1, 0, 0},
                            {1, 0, 1, 0, 1, 0, 1},
                            {0, 1, 0, 1, 0, 0, 0},
                            {0, 0, 1, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0}
                        };

            Position customPosition = new Position(0, 3);
            Playfield playfield = new Playfield(labyrinthGrid, customPosition);

            bool expected = true;
            bool actual = playfield.IsVictory();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsVictory_SouthEndExit()
        {
            int[,] labyrinthGrid = new int[7, 7]
                        {
                            {0, 0, 1, 1, 1, 1, 1},
                            {1, 1, 1, 0, 1, 1, 1},
                            {0, 0, 0, 1, 1, 0, 0},
                            {1, 0, 1, 0, 1, 0, 1},
                            {0, 1, 0, 0, 0, 0, 0},
                            {0, 0, 1, 0, 0, 0, 0},
                            {0, 0, 1, 0, 1, 0, 0}
                        };

            Position customPosition = new Position(6, 3);
            Playfield playfield = new Playfield(labyrinthGrid, customPosition);

            bool expected = true;
            bool actual = playfield.IsVictory();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsVictory_NorthEastCornerExit()
        {
            int[,] labyrinthGrid = new int[7, 7]
                        {
                            {0, 0, 1, 1, 1, 1, 0},
                            {1, 1, 1, 1, 0, 0, 1},
                            {0, 0, 0, 1, 0, 1, 0},
                            {1, 0, 1, 0, 0, 1, 1},
                            {0, 1, 0, 1, 1, 0, 0},
                            {0, 0, 1, 0, 0, 0, 0},
                            {0, 0, 1, 0, 1, 0, 0}
                        };
            Position customPosition = new Position(0, 6);
            Playfield playfield = new Playfield(labyrinthGrid, customPosition);

            bool expected = true;
            bool actual = playfield.IsVictory();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsVictory_NorthWestCornerExit()
        {
            int[,] labyrinthGrid = new int[7, 7]
                        {
                            {0, 0, 1, 1, 1, 1, 0},
                            {1, 1, 1, 1, 0, 0, 1},
                            {0, 0, 0, 1, 0, 1, 0},
                            {1, 0, 1, 0, 0, 1, 1},
                            {0, 1, 0, 1, 1, 0, 0},
                            {0, 0, 1, 0, 0, 0, 0},
                            {0, 0, 1, 0, 1, 0, 0}
                        };
            Position customPosition = new Position(0, 6);
            Playfield playfield = new Playfield(labyrinthGrid, customPosition);

            bool expected = true;
            bool actual = playfield.IsVictory();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsVictory_SoutEastCornerExit()
        {
            int[,] labyrinthGrid = new int[7, 7]
                        {
                            {0, 0, 1, 1, 1, 1, 0},
                            {1, 1, 1, 1, 0, 0, 1},
                            {0, 0, 0, 1, 0, 1, 0},
                            {1, 0, 1, 0, 0, 1, 1},
                            {0, 1, 0, 1, 1, 0, 0},
                            {0, 0, 1, 0, 0, 0, 0},
                            {0, 0, 1, 0, 1, 0, 0}
                        };
            Position customPosition = new Position(6, 6);
            Playfield playfield = new Playfield(labyrinthGrid, customPosition);

            bool expected = true;
            bool actual = playfield.IsVictory();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsVictory_SouthWestCornerExit()
        {
            int[,] labyrinthGrid = new int[7, 7]
                        {
                            {0, 0, 1, 1, 1, 1, 0},
                            {1, 1, 1, 1, 0, 0, 1},
                            {0, 0, 0, 1, 0, 1, 0},
                            {1, 0, 1, 0, 0, 1, 1},
                            {0, 1, 0, 1, 1, 0, 0},
                            {0, 0, 1, 0, 0, 0, 0},
                            {0, 0, 1, 0, 1, 0, 0}
                        };
            Position customPosition = new Position(6, 0);
            Playfield playfield = new Playfield(labyrinthGrid, customPosition);

            bool expected = true;
            bool actual = playfield.IsVictory();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInitializeField_IsCorrectStartPosition()
        {
            Playfield playfield = new Playfield();
            Position expected = new Position(3, 3);
            Position actual = playfield.PlayerPosition;
            Assert.AreEqual(expected.Row, actual.Row);
            Assert.AreEqual(expected.Col, actual.Col);
        }


    }
}
