﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamTellurium.Labyrinth.Tests
{
    [TestClass]
    public class ScoreBoardTest
    {
        [TestMethod]
        public void TestShowScoreboard_WhenEmpty()
        {
            ScoreBoard scoreboard = new ScoreBoard();
            string actualScoreboard = scoreboard.ShowScoreboard().ToString();
            string expectedScoreboard = "Scoreboard is empty. Congratulations, you will be the first who will play that game!";
            Assert.AreEqual(expectedScoreboard, actualScoreboard);
        }

        [TestMethod]
        public void TestShowScoreboard_AddedOnePlayer()
        {
            ScoreBoard scoreboard = new ScoreBoard();
            string actualScoreboard = scoreboard.ShowScoreboard().ToString();
        }
    }
}