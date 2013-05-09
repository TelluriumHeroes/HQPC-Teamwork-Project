using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamTellurium.Labyrinth.Tests
{
    [TestClass]
    public class ScoreBoardTest
    {
        [TestMethod]
        public void TestCreateScoreboard()
        {
            ScoreBoard scoreboard = new ScoreBoard();
            scoreboard.CreateScoreboard();
        }

        [TestMethod]
        public void TestShowScoreboard_EmptyScoreboard()
        {
            ScoreBoard scoreboard = new ScoreBoard();
            scoreboard.CreateScoreboard();
            var actualScoreboardResult = scoreboard.ShowScoreboard();
            //var expectedScoreboardResult = "Scoreboard is empty. Congratulations, you will be the first who will play that game!"
            //Assert.AreEqual(actualScoreboardResult, expectedScoreboardResult);
            
        }
    }
}
