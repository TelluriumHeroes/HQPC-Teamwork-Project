using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTellurium.Labyrinth
{
    public static class Render
    {
        public static void RenderField(int[,] playField, Position Player)
        {
            int rows = playField.GetLength(0);
            int cols = playField.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (Player.x == col && Player.y == row)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        if (playField[col, row] == 0)
                        {
                            Console.Write("-");
                        }
                        else
                        {
                            if (playField[col, row] == 1)
                            {
                                Console.Write("X");
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        public static void ResetField()
        {
        }
    }
}
