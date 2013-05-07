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
            int[,] fieldGrid = playfield.LabyrinthGrid;
            Position playerCurrentPosition = playfield.Player;
            if (playerCurrentPosition.isWinning())
            {
                return false;
            }

            Position newPosition = new Position(playerCurrentPosition.x, playerCurrentPosition.y);

            newPosition.move(nextDirection);

            return IsValidPosition(fieldGrid, newPosition);
        }

        private static bool IsValidPosition(int[,] fieldGrid, Position currentPosition)
        {
            return fieldGrid[currentPosition.x, currentPosition.y] == 0 && currentPosition.isValidPosition();
        }

        public static bool IsBlankMove(int[,] fieldGrid, Position currentPosition, Direction nextDirection)
        {
            Position newPosition = new Position(currentPosition.x, currentPosition.y);
            newPosition.move(nextDirection);

            bool isBlank = (fieldGrid[newPosition.x, newPosition.y] == -1);

            return isBlank;
        }
    }
}
