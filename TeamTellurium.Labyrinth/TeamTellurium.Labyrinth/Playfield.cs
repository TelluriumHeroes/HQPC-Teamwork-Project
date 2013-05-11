using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTellurium.Labyrinth
{
    public class Playfield
    {
        private static int labyrinthGridRows = 7;
        private static int labyrinthGridCols = 7;
        private static Random randomNumberGenerator = new Random();

        public int[,] LabyrinthGrid { get; set; }
        public Position Player { get; private set; }

        public Playfield()
        {
            this.LabyrinthGrid = new int[labyrinthGridRows, labyrinthGridCols];
            this.Player = new Position();
        }

        public Playfield(int[,] customLabyrinth)
        {
            this.LabyrinthGrid = customLabyrinth;
            this.Player = new Position();
        }

        public bool IsWinning()
        {
            return Player.isWinning();
        }

        #region GameFieldStartInitValues

        public void InitializeField()
        {
            this.Player = new Position();

            IntializeEmptyField();

            //Player initial position
            LabyrinthGrid[3, 3] = 0;

            EnsureClearPath();
            InitializeRandomValues();
        }

        private void InitializeRandomValues()
        {
            for (int row = 0; row < labyrinthGridRows; row++)
            {
                for (int col = 0; col < labyrinthGridCols; col++)
                {
                    if (LabyrinthGrid[row, col] == -1)
                    {
                        int randomNumber = randomNumberGenerator.Next();
                        if (randomNumber % 3 == 0)
                        {
                            LabyrinthGrid[row, col] = 0;
                        }
                        else
                        {
                            LabyrinthGrid[row, col] = 1;
                        }
                    }
                }
            }
        }

        private void IntializeEmptyField()
        {
            for (int row = 0; row < labyrinthGridRows; row++)
            {
                for (int col = 0; col < labyrinthGridCols; col++)
                {
                    LabyrinthGrid[row, col] = -1;
                }
            }
        }

        public void EnsureClearPath()
        {
            Direction blankDirection = Direction.Blank;
            Position currentPosition = new Position();

            while (!currentPosition.isWinning())
            {
                do
                {
                    int randomNumber = randomNumberGenerator.Next(-1, 4);
                    blankDirection = (Direction)(randomNumber);

                } while (!MovesChecker.IsBlankMove(this.LabyrinthGrid, currentPosition, blankDirection));

                currentPosition.move(blankDirection);

                LabyrinthGrid[currentPosition.row, currentPosition.col] = 0;
            }
        }

        #endregion
       
        
        private void SetStartRenderingPosition()
        {
            int startRow = 3;
            Console.SetCursorPosition(0, startRow);
        }

        //TODO: Implement!
        public void ResetField()
        {
            throw new NotImplementedException();
        }
    }
}
