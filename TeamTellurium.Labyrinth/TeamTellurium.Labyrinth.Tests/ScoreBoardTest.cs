using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace TeamTellurium.Labyrinth.Tests
{
    [TestClass]
    public class ScoreBoardTest
    {
        [TestMethod]
        public void TestShowScoreboard_WhenEmpty()
        {
            ScoreBoard newScoreboard = new ScoreBoard();
            File.Delete(newScoreboard.GetScoreboardFileLocation());
            var actual = newScoreboard.ShowScoreboard();
            string expected = "Scoreboard is empty. Congratulations, you will be the first who will play that game!";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAddPlayerInScoreboard_Add1Player()
        {
            ScoreBoard newScoreboard = new ScoreBoard();
            File.Delete(newScoreboard.GetScoreboardFileLocation());

            newScoreboard.AddPlayerInScoreboard("Plamen", 1);
            int playerPosition = 0;
            StringBuilder expectedScoreboard = new StringBuilder();
            expectedScoreboard.AppendFormat("{0}: {1} -> {2}", ++playerPosition, "Plamen", 1).AppendLine();
            var actualScoreboard = newScoreboard.ShowScoreboard();

            Assert.AreEqual(expectedScoreboard.ToString(), actualScoreboard);
        }

        [TestMethod]
        public void TestAddPlayerInScoreboard_Add2Players()
        {
            ScoreBoard newScoreboard = new ScoreBoard();
            File.Delete(newScoreboard.GetScoreboardFileLocation());

            newScoreboard.AddPlayerInScoreboard("Plamen", 1);
            newScoreboard.AddPlayerInScoreboard("Ivo", 2);
            int playerPosition = 0;
            StringBuilder expectedScoreboard = new StringBuilder();
            expectedScoreboard.AppendFormat("{0}: {1} -> {2}", ++playerPosition, "Plamen", 1).AppendLine();
            expectedScoreboard.AppendFormat("{0}: {1} -> {2}", ++playerPosition, "Ivo", 2).AppendLine();
            var actualScoreboard = newScoreboard.ShowScoreboard();

            Assert.AreEqual(expectedScoreboard.ToString(), actualScoreboard);
        }
    }
}

