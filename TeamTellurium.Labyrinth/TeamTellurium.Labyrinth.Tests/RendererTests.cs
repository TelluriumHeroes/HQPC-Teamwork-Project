using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamTellurium.Labyrinth.Tests
{
    [TestClass]
    public class RendererTests
    {
        [TestMethod]
        public void TestRenderFieldGrid()
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
        }
    }
}
