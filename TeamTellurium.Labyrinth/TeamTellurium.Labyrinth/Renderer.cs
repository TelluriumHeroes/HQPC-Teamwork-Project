using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTellurium.Labyrinth
{
    public static class Renderer
    {  
        public static void RenderField(Playfield playfield)
        {
            int[,] labyrinthGrid = playfield.LabyrinthGrid;
            Position player = playfield.Player;

            int rows = labyrinthGrid.GetLength(0);
            int cols = labyrinthGrid.GetLength(1);

            StringBuilder fieldAsString = new StringBuilder();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (player.x == col && player.y == row)
                    {
                        fieldAsString.Append("*");
                    }
                    else
                    {
                        if (labyrinthGrid[col, row] == 0)
                        {
                            fieldAsString.Append("-");
                        }
                        else
                        {
                            if (labyrinthGrid[col, row] == 1)
                            {
                                fieldAsString.Append("X");
                            }
                        }
                    }
                }
                fieldAsString.AppendLine();
            }

            Console.WriteLine(fieldAsString.ToString()); 
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
