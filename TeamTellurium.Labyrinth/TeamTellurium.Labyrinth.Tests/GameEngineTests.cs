using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamTellurium.Labyrinth.Tests
{
    [TestClass]
    public class GameEngineTests
    {
        [TestMethod]
        public void TestInitializeNewGame_SetScoresToZero()
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);
            engine.InitializeNewGame();
        }
    }
}
