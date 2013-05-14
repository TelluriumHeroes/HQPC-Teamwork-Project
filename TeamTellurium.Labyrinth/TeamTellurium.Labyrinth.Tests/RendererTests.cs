using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamTellurium.Labyrinth.Tests
{
    [TestClass]
    public class RendererTests
    {
        [TestMethod]
        public void TestRenderFieldGrid_PlayerAtStartPosition()
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

            string actualOutput = Renderer.RenderField(playfield.LabyrinthGrid, 
                playfield.PlayerPosition.Row, playfield.PlayerPosition.Col);

            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("--XX-XX");
            expectedOutput.AppendLine("XXX---X");
            expectedOutput.AppendLine("----X--");
            expectedOutput.AppendLine("X-X*XXX");
            expectedOutput.AppendLine("X--X---");
            expectedOutput.AppendLine("X-X--XX");
            expectedOutput.AppendLine("X--X-X-");
            
            Assert.AreSame(actualOutput, expectedOutput.ToString(), actualOutput.ToString());
        }

        [TestMethod]
        public void TestRenderFieldGrid_PlayerAtOtherPosition()
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

            //Moving playerPosition at row=2 and col=6 (start index=0)
            playfield.PlayerPosition.MoveAtDirection(Direction.Up);
            playfield.PlayerPosition.MoveAtDirection(Direction.Up);
            playfield.PlayerPosition.MoveAtDirection(Direction.Right);
            playfield.PlayerPosition.MoveAtDirection(Direction.Right);
            playfield.PlayerPosition.MoveAtDirection(Direction.Down);
            playfield.PlayerPosition.MoveAtDirection(Direction.Right);

            string actualOutput = Renderer.RenderField(playfield.LabyrinthGrid,
                playfield.PlayerPosition.Row, playfield.PlayerPosition.Col);

            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("--XX-XX");
            expectedOutput.AppendLine("XXX---X");
            expectedOutput.AppendLine("----X-*");
            expectedOutput.AppendLine("X-X-XXX");
            expectedOutput.AppendLine("X--X---");
            expectedOutput.AppendLine("X-X--XX");
            expectedOutput.AppendLine("X--X-X-");

            Assert.AreEqual(actualOutput, expectedOutput.ToString());
        }
    }
}
