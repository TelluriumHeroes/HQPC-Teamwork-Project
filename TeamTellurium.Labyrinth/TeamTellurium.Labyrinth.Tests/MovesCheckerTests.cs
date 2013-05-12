using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamTellurium.Labyrinth.Tests
{
    [TestClass]
    public class MovesCheckerTests
    {
        [TestMethod]
        public void TestIsValidMove_CanMoveRight()
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

            Playfield playfield = new Playfield(labyrinthGrid);
            Directions directionRight = Directions.Right;

            bool expected = true;
            bool actual = MovesChecker.IsValidMove(playfield, directionRight);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsValidMove_CannotMoveRight()
        {
            int[,] labyrinthGrid = new int[7, 7]
                        {
                            {0, 0, 1, 1, 0, 1, 1},
                            {1, 1, 1, 0, 0, 0, 1},
                            {0, 0, 0, 0, 1, 0, 0},
                            {1, 0, 1, 0, 1, 1, 1},
                            {1, 0, 0, 1, 0, 0, 0},
                            {1, 0, 1, 0, 0, 1, 1},
                            {1, 0, 0, 1, 0, 1, 0}
                        };

            Playfield playfield = new Playfield(labyrinthGrid);
            Directions directionRight = Directions.Right;

            bool expected = false;
            bool actual = MovesChecker.IsValidMove(playfield, directionRight);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsValidMove_CanMoveLeft()
        {
            int[,] labyrinthGrid = new int[7, 7]
                        {
                            {0, 0, 1, 0, 1, 1, 1},
                            {1, 0, 0, 0, 1, 1, 1},
                            {0, 0, 1, 1, 0, 0, 0},
                            {1, 0, 0, 0, 0, 1, 1},
                            {0, 1, 0, 1, 0, 0, 0},
                            {0, 0, 1, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0}
                        };

            Playfield playfield = new Playfield(labyrinthGrid);
            Directions directionLeft = Directions.Left;

            bool expected = true;
            bool actual = MovesChecker.IsValidMove(playfield, directionLeft);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsValidMove_CannotMoveLeft()
        {
            int[,] labyrinthGrid = new int[7, 7]
                        {
                            {0, 0, 1, 1, 0, 1, 1},
                            {1, 1, 1, 0, 0, 0, 1},
                            {0, 0, 0, 0, 1, 0, 0},
                            {1, 0, 1, 0, 1, 1, 1},
                            {1, 0, 0, 1, 0, 0, 0},
                            {1, 0, 1, 0, 0, 1, 1},
                            {1, 0, 0, 1, 0, 1, 0}
                        };

            Playfield playfield = new Playfield(labyrinthGrid);
            Directions directionLeft = Directions.Left;

            bool expected = false;
            bool actual = MovesChecker.IsValidMove(playfield, directionLeft);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsValidMove_CanMoveUp()
        {
            int[,] labyrinthGrid = new int[7, 7]
                        {
                            {0, 0, 1, 0, 1, 1, 1},
                            {1, 0, 0, 0, 1, 1, 1},
                            {0, 0, 1, 0, 0, 0, 0},
                            {1, 0, 1, 0, 0, 1, 1},
                            {0, 1, 1, 1, 0, 0, 0},
                            {0, 0, 1, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0}
                        };

            Playfield playfield = new Playfield(labyrinthGrid);
            Directions directionUp = Directions.Up;

            bool expected = true;
            bool actual = MovesChecker.IsValidMove(playfield, directionUp);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsValidMove_CannotMoveUp()
        {
            int[,] labyrinthGrid = new int[7, 7]
                        {
                            {0, 0, 1, 0, 1, 1, 1},
                            {1, 0, 0, 0, 1, 1, 1},
                            {0, 0, 1, 1, 0, 0, 0},
                            {1, 0, 1, 0, 0, 1, 1},
                            {0, 1, 1, 1, 0, 0, 0},
                            {0, 0, 1, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0}
                        };

            Playfield playfield = new Playfield(labyrinthGrid);
            Directions directionUp = Directions.Up;

            bool expected = false;
            bool actual = MovesChecker.IsValidMove(playfield, directionUp);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsValidMove_CanMoveDown()
        {
            int[,] labyrinthGrid = new int[7, 7]
                        {
                            {0, 1, 1, 0, 1, 1, 1},
                            {0, 0, 0, 0, 0, 0, 1},
                            {1, 0, 1, 0, 1, 0, 1},
                            {1, 0, 1, 0, 1, 0, 0},
                            {0, 1, 1, 1, 1, 1, 0},
                            {0, 0, 1, 0, 0, 0, 1},
                            {1, 0, 0, 0, 0, 0, 0}
                        };

            Playfield playfield = new Playfield(labyrinthGrid);

            //Moving playerPosition at row=5 and col=2
            playfield.PlayerPosition.move(Directions.Up);
            playfield.PlayerPosition.move(Directions.Up);
            playfield.PlayerPosition.move(Directions.Right);
            playfield.PlayerPosition.move(Directions.Right);
            playfield.PlayerPosition.move(Directions.Down);

            Directions directionDown = Directions.Down;
            bool expected = true;
            bool actual = MovesChecker.IsValidMove(playfield, directionDown);
            Assert.AreEqual(expected, actual);
        }
    }
}
