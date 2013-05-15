using System;

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

        public Playfield(Position customStartPosition) : this()
        {
            if (customStartPosition == null)
            {
                throw new NullReferenceException("Invalid position!" + customStartPosition.GetType().Name + " cannot be null");
            }
            if (customStartPosition.Row >= labyrinthGridRows ||
                customStartPosition.Col >= labyrinthGridCols)
            {
                throw new IndexOutOfRangeException(
                   String.Format("The numbers of the custom position rows and cols must not be bigger than rows = {0} and cols = {1}! Your input: row = {0} and col = {1}",
                           Playfield.labyrinthGridRows, Playfield.labyrinthGridCols, customStartPosition.Row, customStartPosition.Col));
            }
            this.PlayerPosition = customStartPosition;
        }

        public Playfield(int[,] customLabyrinth)
        {
            if (customLabyrinth.GetLength(0) != labyrinthGridRows ||
                customLabyrinth.GetLength(1) != labyrinthGridCols)
            {
                throw new IndexOutOfRangeException(
                    String.Format("The index of the custom labyrinth must not be bigger than rows = {0} and cols = {1}! Your input: row = {0} and col = {1}",
                            Playfield.labyrinthGridRows, Playfield.labyrinthGridCols, customLabyrinth.GetLength(0), customLabyrinth.GetLength(1)));
            }
            this.LabyrinthGrid = customLabyrinth;
            this.PlayerPosition = new Position();
        }

        public Playfield(int[,] customLabyrinth, Position customStartPosition) : this(customLabyrinth)
        {
            if (customStartPosition == null)
            {
                throw new NullReferenceException("Invalid position! Must not be null.");
            }
            if (customStartPosition.Row >= labyrinthGridRows || 
                customStartPosition.Col >= labyrinthGridCols)
            {
                throw new IndexOutOfRangeException(
                   String.Format("The numbers of the custom position rows and cols must not be bigger than rows = {0} and cols = {1}! Your input: row = {0} and col = {1}",
                           Playfield.labyrinthGridRows, Playfield.labyrinthGridCols, customStartPosition.Row, customStartPosition.Col));
            }
            this.PlayerPosition = customStartPosition;
        }

        public bool IsVictory()
        {
            return this.PlayerPosition.IsWinner();
        }

        #region StartInitValues

        public void InitializeField()
        {
            this.PlayerPosition.SetStartPosition();
            this.IntializeEmptyField();
            //Player initial position
            this.LabyrinthGrid[PlayerPosition.Row, PlayerPosition.Col] = 0;
            this.EnsureClearPath();
            this.InitializeRandomValues();
        }

        public void EnsureClearPath()
        {
            Direction nextDirection = new Direction();
            Position currentPosition = new Position();

            while (!currentPosition.IsWinner())
            {
                int randomNumber = randomNumberGenerator.Next(-1, 4);
                nextDirection = (Direction)(randomNumber);
                if (!MovesChecker.IsValidMove(this, nextDirection))
                {
                    currentPosition.MoveAtDirection(nextDirection);

                    this.LabyrinthGrid[currentPosition.Row, currentPosition.Col] = 0;
                }
            }
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

        #endregion
    }
}