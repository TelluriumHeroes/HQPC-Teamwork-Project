using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamTellurium.Labyrinth.Tests
{
    [TestClass]
    public class ScoreBoardTest
    {
        [TestMethod]
        public void CreateScoreboard()
        {
            ScoreBoard scoreboard = new ScoreBoard();
            scoreboard.CreateScoreboard();
        }
    }
}
