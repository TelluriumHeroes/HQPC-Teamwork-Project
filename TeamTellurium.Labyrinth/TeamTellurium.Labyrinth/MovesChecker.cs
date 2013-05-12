using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTellurium.Labyrinth
{
    public static class MovesChecker
    {
        public static bool IsValidMove(Playfield playfield, Direction nextDirection)
        {   
            Position playerCurrentPosition = playfield.Player;
            if (playerCurrentPosition.isWinning())
            {
                return false;
            }

            Position newPosition = new Position(playerCurrentPosition.row, playerCurrentPosition.col);
            newPosition.move(nextDirection);

            int[,] fieldGrid = playfield.LabyrinthGrid;
            return IsValidPosition(fieldGrid, newPosition);
        }

        private static bool IsValidPosition(int[,] fieldGrid, Position currentPosition)
        {
            return fieldGrid[currentPosition.row, currentPosition.col] == 0 && currentPosition.isValidPosition();
        }

        public static bool IsBlankMove(int[,] fieldGrid, Position currentPosition, Direction nextDirection)
        {
            Position newPosition = new Position(currentPosition.row, currentPosition.col);
            newPosition.move(nextDirection);

            bool isBlank = (fieldGrid[newPosition.row, newPosition.col] == -1);

            return isBlank;
        }
    }
}
