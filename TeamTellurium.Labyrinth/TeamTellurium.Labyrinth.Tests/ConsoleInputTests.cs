using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamTellurium.Labyrinth.Tests
{
    [TestClass]
    public class ConsoleInputTests
    {
        [TestMethod]
        public void TestProcessInput_OnWriteL()
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);
            AssignEvents(engine, engine.UserInput);
            engine.UserInput.ProcessInput("L");

            Position expected = new Position(3, 2);
            Position actual = playfield.PlayerPosition;

            Assert.AreEqual(expected.Row, actual.Row);
            Assert.AreEqual(expected.Col, actual.Col);

        }

        [TestMethod]
        public void TestProcessInput_OnWriteR()
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);
            AssignEvents(engine, engine.UserInput);
            engine.UserInput.ProcessInput("R");

            Position expected = new Position(3, 4);
            Position actual = playfield.PlayerPosition;

            Assert.AreEqual(expected.Row, actual.Row);
            Assert.AreEqual(expected.Col, actual.Col);
        }

        [TestMethod]
        public void TestProcessInput_OnWriteD()
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);
            AssignEvents(engine, engine.UserInput);
            engine.UserInput.ProcessInput("D");

            Position expected = new Position(4, 3);
            Position actual = playfield.PlayerPosition;

            Assert.AreEqual(expected.Row, actual.Row);
            Assert.AreEqual(expected.Col, actual.Col);
        }

        [TestMethod]
        public void TestProcessInput_OnWriteU()
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);
            AssignEvents(engine, engine.UserInput);
            engine.UserInput.ProcessInput("U");

            Position expected = new Position(2, 3);
            Position actual = playfield.PlayerPosition;

            Assert.AreEqual(expected.Row, actual.Row);
            Assert.AreEqual(expected.Col, actual.Col);
        }

        [TestMethod]
        public void TestProcessInput_OnWriteExit()
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);
            AssignEvents(engine, engine.UserInput);
            engine.UserInput.ProcessInput("exit");

            bool expected = true;
            bool actual = engine.HasGameQuit;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void TestProcessInput_OnWriteRestart()
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);
            AssignEvents(engine, engine.UserInput);
            engine.UserInput.ProcessInput("restart");

            int expected = 0;
            int actual = engine.Score;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void TestProcessInput_OnWriteTop()
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);
            AssignEvents(engine, engine.UserInput);
            engine.UserInput.ProcessInput("top");

            string expected = engine.GetTopResults();
            string actual = new ScoreBoard().ShowScoreboard();
            Assert.AreEqual(expected, actual);
        }

        private static void AssignEvents(GameEngine engine, ConsoleInput movement)
        {
            movement.OnWriteL += (sender, eventInfo) => engine.MoveAtDirection(Direction.Left, engine.MoveLeft);
            movement.OnWriteR += (sender, eventInfo) => engine.MoveAtDirection(Direction.Right, engine.MoveRight);
            movement.OnWriteU += (sender, eventInfo) => engine.MoveAtDirection(Direction.Up, engine.MoveUp);
            movement.OnWriteD += (sender, eventInfo) => engine.MoveAtDirection(Direction.Down, engine.MoveDown);
            
            movement.OnWriteTop += (sender, eventInfo) => engine.ShowTopResults();
            movement.OnWriteRestart += (sender, eventInfo) => engine.InitializeNewGame();
            movement.OnWriteExit += (sender, eventInfo) => engine.QuitGame();

            //Assert.AreSame(movement.OnWriteL == movement.OnWriteL);
        }
    }
}
