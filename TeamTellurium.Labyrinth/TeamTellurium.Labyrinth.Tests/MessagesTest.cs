using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamTellurium.Labyrinth.Tests
{
    [TestClass]
    public class MessagesTest
    {
        [TestMethod]
        public void TestInvalidMoveMessage()
        {
            Messages message = new Messages();
            string actualMessage = message.InvalidMoveMessage();
            string expectedMesage = "Invalid move!";

            Assert.AreEqual(expectedMesage, actualMessage);
        }

        [TestMethod]
        public void TestMoveInstructionsMessage()
        {
            Messages message = new Messages();
            string actualMessage = message.MoveInstructionsMessage();
            string expectedMesage = "Enter your move (L=left, R=right, U=up, D=down): ";

            Assert.AreEqual(expectedMesage, actualMessage);
        }

        [TestMethod]
        public void TestWelcomeMessage()
        {
            Messages message = new Messages();
            string actualMessage = message.WelcomeMessage();
            string expectedMesage = "Welcome to \"Labyrinth\" game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.";

            Assert.AreEqual(expectedMesage, actualMessage);
        }

        [TestMethod]
        public void TestNewLine()
        {
            Messages message = new Messages();
            string actualMessage = message.NewLine();
            string expectedMesage = Environment.NewLine;

            Assert.AreEqual(expectedMesage, actualMessage);
        }

        [TestMethod]
        public void TestWinnerCongratsMessage_With3Moves()
        {
            Messages message = new Messages();
            int moves = 3;
            string actualMessage = message.WinnerCongratsMessage(moves);
            string expectedMesage = "Congratulations! You escaped in " + moves + " moves!\nPlease enter your name for the top scoreboard: ";

            Assert.AreEqual(expectedMesage, actualMessage);
        }

        [TestMethod]
        public void TestWinnerCongratsMessage_With0Moves()
        {
            Messages message = new Messages();
            int moves = 0;
            string actualMessage = message.WinnerCongratsMessage(moves);
            string expectedMesage = "Congratulations! You escaped in " + moves + " moves!\nPlease enter your name for the top scoreboard: ";

            Assert.AreEqual(expectedMesage, actualMessage);
        }
     
        [TestMethod]
        public void TestPlayingInstructionsMessage()
        {
            Messages message = new Messages();
            string actualMessage = message.PlayingInstructionsMessage();
            string expectedMesage = "You are playing \"Labyrinth\" game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.";

            Assert.AreEqual(expectedMesage, actualMessage);
        }
    }
}
