using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTellurium.Labyrinth
{
    public class Playfield
    {
        private static Random RandomNumberGenerator = new Random();
        private static int LabyrinthGridRows = 7;
        private static int LabyrinthGridCols = 7;

        public int[,] LabyrinthGrid { get; private set; }
        public Position PlayerPosition { get; private set; }

        public Playfield()
        {
            this.LabyrinthGrid = new int[LabyrinthGridRows, LabyrinthGridCols];
            this.PlayerPosition = new Position();
        }

        public Playfield(int[,] customLabyrinth)
        {
            this.LabyrinthGrid = customLabyrinth;
            this.PlayerPosition = new Position();
        }

        public bool IsWinning()
        {
            return PlayerPosition.IsWinner();
        }

        #region GameFieldStartInitValues

        public void InitializeField()
        {
            this.PlayerPosition = new Position();
            IntializeEmptyField();
            //Player initial position
            LabyrinthGrid[3, 3] = 0;
            EnsureClearPath();
            InitializeRandomValues();
        }

        private void InitializeRandomValues()
        {
            for (int row = 0; row < LabyrinthGridRows; row++)
            {
                for (int col = 0; col < LabyrinthGridCols; col++)
                {
                    if (LabyrinthGrid[row, col] == -1)
                    {
                        int randomNumber = RandomNumberGenerator.Next();
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
            for (int row = 0; row < LabyrinthGridRows; row++)
            {
                for (int col = 0; col < LabyrinthGridCols; col++)
                {
                    LabyrinthGrid[row, col] = -1;
                }
            }
        }

        public void EnsureClearPath()
        {
            Directions nextDirection = new Directions();
            Position currentPosition = new Position();

            while (!currentPosition.IsWinner())
            {
                int randomNumber = RandomNumberGenerator.Next(-1, 4);
                nextDirection = (Directions)(randomNumber);
                if (!MovesChecker.IsValidMove(this, nextDirection))
                {
                    currentPosition.IsMoved(nextDirection);

                    this.LabyrinthGrid[currentPosition.Row, currentPosition.Col] = 0;
                }
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
