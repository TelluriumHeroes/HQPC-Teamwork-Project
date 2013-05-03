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

        public int[,] LabyrinthGrid { get; private set; }
        public Position Player { get; private set; }

        public Playfield()
        {
            this.LabyrinthGrid = new int[labyrinthGridRows, labyrinthGridCols];
            this.Player = new Position();
        }

        //Here//
        public bool IsWinning()
        {
            return Player.isWinning();
        }

        public bool TryMove(Direction direction)
        {
            if (IsValidMove(Player, direction))
            {
                Player.move(direction);
            }
            else
            {
                return false;
            }
            return true;
        }

        bool IsValidPosition(Position currentPosition)
        {
            return LabyrinthGrid[currentPosition.x, currentPosition.y] == 0 && currentPosition.isValidPosition();
        }

        bool IsValidMove(Position currentPosition, Direction nextDirection)
        {
            if (currentPosition.isWinning())
            {
                return false;
            }

            Position newPosition = new Position(currentPosition.x, currentPosition.y);

            newPosition.move(nextDirection);

            return IsValidPosition(newPosition);
        }

        public bool IsBlankMove(Position currentPosition, Direction nextDirection)
        {
            Position newPosition = new Position(currentPosition.x, currentPosition.y);
            newPosition.move(nextDirection);

            bool isBlank = (this.LabyrinthGrid[newPosition.x, newPosition.y] == -1);

            return isBlank;
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

                } while (!IsBlankMove(currentPosition, blankDirection));

                currentPosition.move(blankDirection);

                LabyrinthGrid[currentPosition.x, currentPosition.y] = 0;
            }
        }

        #endregion
       
        private void SetStartRenderingPosition()
        {
            int startRow = 3;
            Console.SetCursorPosition(0, startRow);
        }



        public void ResetField()
        {
            throw new NotImplementedException();
        }
    }
}
