using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTellurium.Labyrinth
{
    public class Position
    {
        private const int INITIAL_ROW = 3;
        private const int INITIAL_COL = 3;
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
            }
        }

        public Position()
        {
            this.row = INITIAL_ROW;
            this.col = INITIAL_COL;
        }

        public Position(int xCoordinate, int yCoordinate)
        {
            this.row = xCoordinate;
            this.col = yCoordinate;
        }

        public bool Move(Directions direction)
        {
            if (IsWinning())
            { 
                return false; 
            
            }
            switch (direction)
            {
                case Directions.Left:
                    this.col -= 1;
                    break;
                case Directions.Up:
                    this.row -= 1;
                    break;
                case Directions.Right:
                    this.col += 1;
                    break;
                case Directions.Down:
                    this.row += 1;
                    break;
                default:
                    return false;
            }
            return true;
        }

        public bool IsWinning()
        {
            bool isWinner = false;

            if (row == 0 || row == 6 || col == 0 || col == 6)
            {
                isWinner = true;
            }

            return isWinner;
        }

        public bool IsValidPosition()
        {
            if (row <= 6 && row >= 0 && col >= 0 && col <= 6)
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
            this.row = INITIAL_ROW;
            this.col = INITIAL_COL;
        }
    }
}
