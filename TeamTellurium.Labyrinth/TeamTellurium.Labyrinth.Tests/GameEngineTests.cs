using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamTellurium.Labyrinth.Tests
{
    [TestClass]
    public class GameEngineTests
    {
        [TestMethod]
        public void TestMoveLeft()
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);
            engine.MoveLeft();

            Position expected = new Position(3, 2);
            Position actual = playfield.PlayerPosition;
            Assert.AreEqual(expected.Row, actual.Row);
            Assert.AreEqual(expected.Col, actual.Col);
        }

        [TestMethod]
        public void TestMoveRight()
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);
            engine.MoveRight();

            Position expected = new Position(3, 4);
            Position actual = playfield.PlayerPosition;
            Assert.AreEqual(expected.Row, actual.Row);
            Assert.AreEqual(expected.Col, actual.Col);
        }

        [TestMethod]
        public void TestMoveUp()
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);
            engine.MoveUp();

            Position expected = new Position(2, 3);
            Position actual = playfield.PlayerPosition;
            Assert.AreEqual(expected.Row, actual.Row);
            Assert.AreEqual(expected.Col, actual.Col);
        }

        [TestMethod]
        public void TestMoveDown()
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);
            engine.MoveDown();

            Position expected = new Position(4, 3);
            Position actual = playfield.PlayerPosition;
            Assert.AreEqual(expected.Row, actual.Row);
            Assert.AreEqual(expected.Col, actual.Col);
        }

        [TestMethod]
        public void TestMoveAtDirection_ScoreIsUpdatedOnMoveLeft()
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);

            engine.MoveAtDirection(Direction.Left, engine.MoveLeft);

            int expected = 1;
            int actual = engine.Score;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMoveAtDirection_ScoreIsUpdatedOnMoveRight()
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);

            engine.MoveAtDirection(Direction.Right, engine.MoveRight);

            int expected = 1;
            int actual = engine.Score;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMoveAtDirection_ScoreIsUpdatedOnMoveUp()
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);

            engine.MoveAtDirection(Direction.Up, engine.MoveUp);

            int expected = 1;
            int actual = engine.Score;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMoveAtDirection_ScoreIsUpdatedOnMoveDown()
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);

            engine.MoveAtDirection(Direction.Down, engine.MoveDown);

            int expected = 1;
            int actual = engine.Score;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMoveAtDirection_MoveAtLeft()
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);
            engine.MoveAtDirection(Direction.Left, engine.MoveLeft);

            Position expected = new Position(3, 2);
            Position actual = playfield.PlayerPosition;
            Assert.AreEqual(expected.Row, actual.Row);
            Assert.AreEqual(expected.Col, actual.Col);
        }

        [TestMethod]
        public void TestMoveAtDirection_MoveAtRight()
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);
            engine.MoveAtDirection(Direction.Right, engine.MoveRight);

            Position expected = new Position(3, 4);
            Position actual = playfield.PlayerPosition;
            Assert.AreEqual(expected.Row, actual.Row);
            Assert.AreEqual(expected.Col, actual.Col);
        }

        [TestMethod]
        public void TestMoveAtDirection_MoveAtUp()
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);
            engine.MoveAtDirection(Direction.Up, engine.MoveUp);

            Position expected = new Position(2, 3);
            Position actual = playfield.PlayerPosition;
            Assert.AreEqual(expected.Row, actual.Row);
            Assert.AreEqual(expected.Col, actual.Col);
        }

        [TestMethod]
        public void TestMoveAtDirection_MoveAtDown()
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);
            engine.MoveAtDirection(Direction.Down, engine.MoveDown);

            Position expected = new Position(4, 3);
            Position actual = playfield.PlayerPosition;
            Assert.AreEqual(expected.Row, actual.Row);
            Assert.AreEqual(expected.Col, actual.Col);
        }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void TestInitializeNewGame_ScoreIsUpdated()
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);
            engine.MoveAtDirection(Direction.Down, engine.MoveDown);
            engine.InitializeNewGame();

            int expected = 0;
            int actual = engine.Score;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnQuitGame()
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);
            engine.QuitGame();
            bool expected = true;
            bool actual = engine.HasGameQuit;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetTopResults()
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);

            string expected = engine.GetTopResults();
            string actual = new ScoreBoard().ShowScoreboard();
            Assert.AreEqual(expected, actual);
        }
        
    }
}
