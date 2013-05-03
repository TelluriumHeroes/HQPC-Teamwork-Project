using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTellurium.Labyrinth
{
    public static class MovesChecker
    {
        public static bool TryMove(Playfield playfield, Direction direction)
        {
            int[,] fieldGrid = playfield.LabyrinthGrid;
            Position player = playfield.Player;
            if (IsValidMove(fieldGrid, player, direction))
            {
                player.move(direction);
            }
            else
            {
                return false;
            }
            return true;
        }

        private static bool IsValidMove(int[,] fieldGrid, Position currentPosition, Direction nextDirection)
        {
            if (currentPosition.isWinning())
            {
                return false;
            }

            Position newPosition = new Position(currentPosition.x, currentPosition.y);

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
