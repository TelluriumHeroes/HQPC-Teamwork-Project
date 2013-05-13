namespace TeamTellurium.Labyrinth
{
    using System;
    using System.Linq;

    public class Position
    {
        private const int Y_INITIAL_POSITION = 3;
        private const int X_INITIAL_POSITION = 3;
        private const int MOVING_STEP = 1;
        private const int LEFT_ESCAPE_POSITION = 0;
        private const int RIGTH_ESCAPE_POSITION = 6;
        private const int TOP_ESCAPE_POSITION = 0;
        private const int BOTTOM_ESCAPE_POSITION = 6;
        private int row;
        private int col;

        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                if (value > 0)
                {
                    this.Row = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Can't go outside of the bounds of the playfield");
                }
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }

            set
            {
                if (value > 0)
                {
                    this.Col = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Can't go outside of the bounds of the playfield");
                }
            }
        }

        public Position()
        {
            this.row = Y_INITIAL_POSITION;
            this.col = X_INITIAL_POSITION;
        }

        public Position(int xCoordinate, int yCoordinate)
        {
            this.row = xCoordinate;
            this.col = yCoordinate;
        }

        public bool IsMoved(Directions direction)
        {
            if (this.IsWinner())
            {
                return false;
            }

            switch (direction)
            {
                case Directions.Left:
                    this.col -= MOVING_STEP;
                    break;
                case Directions.Up:
                    this.row -= MOVING_STEP;
                    break;
                case Directions.Right:
                    this.col += MOVING_STEP;
                    break;
                case Directions.Down:
                    this.row += MOVING_STEP;
                    break;
                default:
                    return false;
            }

            return true;
        }

        public bool IsWinner()
        {
            bool isWinner = false;

            if (this.row == TOP_ESCAPE_POSITION || this.row == BOTTOM_ESCAPE_POSITION
                || this.col == LEFT_ESCAPE_POSITION || this.col == RIGTH_ESCAPE_POSITION)
            {
                isWinner = true;
            }

            return isWinner;
        }

        public bool IsValidPosition()
        {
            bool yCoordinatesInRange = (this.row <= 6 && this.row >= 0);
            bool xCoordinatesInRange = (this.col >= 0 && this.col <= 6);

            if (xCoordinatesInRange && yCoordinatesInRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void MakeStarting()
        {
            this.row = Y_INITIAL_POSITION;
            this.col = X_INITIAL_POSITION;
        }
    }
}