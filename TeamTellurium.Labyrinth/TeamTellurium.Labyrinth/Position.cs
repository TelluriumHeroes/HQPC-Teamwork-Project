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
        private const int INITIAL_COW = 3;
        private int row;
        private int col;
        
        public int Row
        {
            get;
            set;
        }

        public int Col
        {
            get;
            set;
        }

        public Position()
        {
            this.row = INITIAL_ROW;
            this.col = INITIAL_COW;
        }

        public Position(int x, int y)
        {
            this.row = x;
            this.col = y;
        }

        public bool move(Directions direction)
        {
            if (isWinning()) return false;
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

        public bool isWinning()
        {
            bool result;
            result = false;
            if (row == 0 || row == 6 || col == 0 || col == 6)
                result = true;
            return result;
        }



        public bool isValidPosition()
        {
            if (row <= 6 && row >= 0 && col >= 0 && col <= 6) return true;
            else return false;
        }

        public void makeStarting()
        {
            this.row = 3;
            this.col = 3;
        }
    }
}
