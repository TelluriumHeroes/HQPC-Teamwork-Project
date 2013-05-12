using System;
using System.Text;

namespace TeamTellurium.Labyrinth
{
    public static class Renderer
    {
        public static string RenderField(Playfield playfield)
        {
            int[,] labyrinthGrid = playfield.LabyrinthGrid;
            Position player = playfield.PlayerPosition;
            int rows = labyrinthGrid.GetLength(0);
            int cols = labyrinthGrid.GetLength(1);

            StringBuilder fieldAsString = new StringBuilder();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (player.row == row && player.col == col)
                    {
                        fieldAsString.Append("*");
                    }
                    else
                    {
                        if (labyrinthGrid[row, col] == 0)
                        {
                            fieldAsString.Append("-");
                        }
                        else
                        {
                            if (labyrinthGrid[row, col] == 1)
                            {
                                fieldAsString.Append("X");
                            }
                        }
                    }
                }
                fieldAsString.AppendLine();
            }
            Console.WriteLine(fieldAsString.ToString());

            //For testing purpose only
            return fieldAsString.ToString();
        }

        public static void RenderScoreboard(string score)
        {
            Console.WriteLine(score);
        }

        public static void ResetField()
        {
        }
    }
}
