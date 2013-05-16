namespace TeamTellurium.Labyrinth
{
    using System;
    using System.Text;

    public static class Renderer
    {
        public static string RenderField(int[,] gamefieldGrid, int currentPosRow, int currentPosCol)
        {
            int rows = gamefieldGrid.GetLength(0);
            int cols = gamefieldGrid.GetLength(1);

            StringBuilder fieldAsString = new StringBuilder();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (currentPosRow == row && currentPosCol == col)
                    {
                        fieldAsString.Append("*");
                    }
                    else
                    {
                        if (gamefieldGrid[row, col] == 0)
                        {
                            fieldAsString.Append("-");
                        }
                        else
                        {
                            fieldAsString.Append("X");
                        }
                    }
                }

                fieldAsString.AppendLine();
            }

            Console.SetCursorPosition(0, 3);
            Console.WriteLine(fieldAsString.ToString());
            Console.SetCursorPosition(49, 11);

            return fieldAsString.ToString();
        }

        public static void RenderInfo(string welcomeMessage, string moveInstructions)
        {   
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(welcomeMessage + Environment.NewLine);
            Console.SetCursorPosition(0, 11);
            Console.Write(moveInstructions);
        }
        
        public static void RenderWinInfo(string winMessage)
        {
            Console.WriteLine();
            Console.Write(Environment.NewLine + winMessage);
        }

        public static void RenderScoreboard(string score)
        {
            Console.WriteLine(score);
        }

        public static void ResetField()
        {
            Console.Clear();
        }
    }
}