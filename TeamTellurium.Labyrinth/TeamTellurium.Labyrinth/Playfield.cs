using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTellurium.Labyrinth
{
    public class Playfield
    {
        private static readonly Random randomNumberGenerator = new Random();
        private static readonly int labyrinthGridRows = 7;
        private static readonly int labyrinthGridCols = 7;

        public int[,] LabyrinthGrid { get; private set; }
        public Position PlayerPosition { get; private set; }

        public Playfield()
        {
            this.LabyrinthGrid = new int[labyrinthGridRows, labyrinthGridCols];
            this.PlayerPosition = new Position();
        }

        public Playfield(int[,] customLabyrinth)
        {
            this.LabyrinthGrid = customLabyrinth;
            this.PlayerPosition = new Position();
        }

        public bool IsVictory()
        {
            return this.PlayerPosition.IsWinner();
        }

        #region GameFieldStartInitValues

        public void InitializeField()
        {
            this.PlayerPosition = new Position();
            this.IntializeEmptyField();
            //Player initial position
            this.LabyrinthGrid[3, 3] = 0;
            this.EnsureClearPath();
            this.InitializeRandomValues();
        }

        public void EnsureClearPath()
        {
            Directions nextDirection = new Directions();
            Position currentPosition = new Position();

            while (!currentPosition.IsWinner())
            {
                int randomNumber = randomNumberGenerator.Next(-1, 4);
                nextDirection = (Directions)(randomNumber);
                if (!MovesChecker.IsValidMove(this, nextDirection))
                {
                    currentPosition.MoveAtDirection(nextDirection);

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
                            this.LabyrinthGrid[row, col] = 0;
                        }
                        else
                        {
                            this.LabyrinthGrid[row, col] = 1;
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
                    this.LabyrinthGrid[row, col] = -1;
                }
            }
        }
    }
}