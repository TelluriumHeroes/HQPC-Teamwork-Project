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
            ScoreBoard scoreboard = new ScoreBoard();
            File.Delete(scoreboard.GetScoreboardFileLocation());
            var actual = scoreboard.ShowScoreboard();
            string expected = "Scoreboard is empty. Congratulations, you will be the first who will play that game!";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAddPlayerInScoreboard_Add1Player()
        {
            ScoreBoard scoreboard = new ScoreBoard();
            File.Delete(scoreboard.GetScoreboardFileLocation());

            scoreboard.AddPlayerInScoreboard("Plamen", 1);
            int playerPosition = 0;

            StringBuilder expectedScoreboard = new StringBuilder();
            expectedScoreboard.AppendFormat("{0}: {1} -> {2}", ++playerPosition, "Plamen", 1).AppendLine();
            var actualScoreboard = scoreboard.ShowScoreboard();

            Assert.AreEqual(expectedScoreboard.ToString(), actualScoreboard);
        }

        [TestMethod]
        public void TestAddPlayerInScoreboard_Add2Players()
        {
            ScoreBoard scoreboard = new ScoreBoard();
            File.Delete(scoreboard.GetScoreboardFileLocation());

            scoreboard.AddPlayerInScoreboard("Plamen", 1);
            scoreboard.AddPlayerInScoreboard("Ivo", 2);
            int playerPosition = 0;

            StringBuilder expectedScoreboard = new StringBuilder();
            expectedScoreboard.AppendFormat("{0}: {1} -> {2}", ++playerPosition, "Plamen", 1).AppendLine();
            expectedScoreboard.AppendFormat("{0}: {1} -> {2}", ++playerPosition, "Ivo", 2).AppendLine();
            var actualScoreboard = scoreboard.ShowScoreboard();

            Assert.AreEqual(expectedScoreboard.ToString(), actualScoreboard);
        }

        [TestMethod]
        public void TestGetScoreboardFileLocation()
        {
            ScoreBoard scoreboard = new ScoreBoard();
            string scoreboardActualLocation = scoreboard.GetScoreboardFileLocation();
            string scoreboardExpectedLocation = "../../scoreboard.txt";

            Assert.AreEqual(scoreboardExpectedLocation, scoreboardActualLocation);
        }
    }
}

