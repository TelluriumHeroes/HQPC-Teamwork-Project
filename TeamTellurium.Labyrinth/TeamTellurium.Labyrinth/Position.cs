namespace TeamTellurium.Labyrinth
{
    using System;
    using System.Linq;

    public class Position : IMovable
    {
        private const byte ROW_INITIAL_POSITION = 3;
        private const byte COL_INITIAL_POSITION = 3;
        private const byte MOVING_STEP = 1;
        private const byte LEFT_ESCAPE_POSITION = 0;
        private const byte RIGTH_ESCAPE_POSITION = 6;
        private const byte TOP_ESCAPE_POSITION = 0;
        private const byte BOTTOM_ESCAPE_POSITION = 6;
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
                if (TOP_ESCAPE_POSITION <= value && value <= BOTTOM_ESCAPE_POSITION)
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
                if (LEFT_ESCAPE_POSITION <= value && value <= RIGTH_ESCAPE_POSITION)
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
            this.row = ROW_INITIAL_POSITION;
            this.col = COL_INITIAL_POSITION;
        }

        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public void MoveAtDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    this.Col -= MOVING_STEP;
                    break;
                case Direction.Up:
                    this.Row -= MOVING_STEP;
                    break;
                case Direction.Right:
                    this.Col += MOVING_STEP;
                    break;
                default:
                    this.Row += MOVING_STEP;
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
            this.row = ROW_INITIAL_POSITION;
            this.col = COL_INITIAL_POSITION;
        }
    }
}