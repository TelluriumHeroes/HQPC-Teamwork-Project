using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamTellurium.Labyrinth.Tests
{
    [TestClass]
    public class PlayfieldTests
    {
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestPlayfield_CustomLabyrinthRowsOutOfRange()
        {
            int[,] labyrinthGrid = new int[8, 7]
                        {
                            {0, 0, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1},
                            {0, 0, 0, 0, 0, 0, 0},
                            {1, 0, 1, 0, 0, 1, 1},
                            {0, 1, 0, 1, 0, 0, 0},
                            {0, 0, 1, 0, 0, 0, 0},
                            {0, 0, 0, 0, 0, 0, 0},
                            {1, 0, 1, 0, 0, 1, 1}
                        };

            Playfield playfield = new Playfield(labyrinthGrid);
        }
    }
}
