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
                    this.row = value;
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
                    this.col = value;
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

        public void MoveAtDirection(Directions direction)
        {
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
                default:
                    this.row += MOVING_STEP;
                    break;
            }
        }

        public bool IsWinner()
        {
            if (this.row == TOP_ESCAPE_POSITION || this.row == BOTTOM_ESCAPE_POSITION
                || this.col == LEFT_ESCAPE_POSITION || this.col == RIGTH_ESCAPE_POSITION)
            {
                return true;
            }

            return false;
        }

        public void SetStartPosition()
        {
            this.row = Y_INITIAL_POSITION;
            this.col = X_INITIAL_POSITION;
        }
    }
}