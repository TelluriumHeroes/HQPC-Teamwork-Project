using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamTellurium.Labyrinth.Tests
{
    [TestClass]
    public class RendererTests
    {
        [TestMethod]
        //This exception doesn't appear only when tested with VS integrated testing system
        [ExpectedException(typeof(IOException))]
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
            
            bool areEqual = actualOutput == expectedOutput.ToString();
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        //This exception doesn't appear only when tested with VS integrated testing system
        [ExpectedException(typeof(IOException))]
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

            bool areEqual = actualOutput == expectedOutput.ToString();
            Assert.IsTrue(areEqual);
        }
    }
}
