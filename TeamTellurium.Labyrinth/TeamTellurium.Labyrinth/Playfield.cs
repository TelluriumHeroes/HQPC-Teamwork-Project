namespace TeamTellurium.Labyrinth
{
    using System;

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
            if (customStartPosition.Row >= labyrinthGridRows || 
                customStartPosition.Col >= labyrinthGridCols)
            {
                throw new IndexOutOfRangeException(
                   String.Format("The numbers of the custom position rows and cols must not be bigger than rows = {0} and cols = {1}! Your input: row = {0} and col = {1}",
                           Playfield.labyrinthGridRows, Playfield.labyrinthGridCols, customStartPosition.Row, customStartPosition.Col));
            }
            this.PlayerPosition = customStartPosition;
        }

        /// <summary>
        /// Checks if current player position is at the end of the playfield
        /// </summary>
        /// <returns>A bool value with checked position</returns>
        public bool IsVictory()
        {
            return this.PlayerPosition.IsWinner();
        }

        #region StartInitValues

        /// <summary>
        /// Initialize random playfield
        /// </summary>
        public void InitializeField()
        {
            this.PlayerPosition.SetStartPosition();
            this.IntializeEmptyField();
            this.LabyrinthGrid[PlayerPosition.Row, PlayerPosition.Col] = 0;
            this.EnsureClearPath();
            this.InitializeRandomValues();
        }

        /// <summary>
        /// Ensure clear escaping path from player start position
        /// </summary>
        private void EnsureClearPath()
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

        /// <summary>
        /// Initialize random values between 0 and 1 in the playfield
        /// </summary>
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

        /// <summary>
        /// Intialize 'empty' playfield with values equals to -1
        /// </summary>
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