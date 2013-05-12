using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTellurium.Labyrinth
{
    public static class MovesChecker
    {
        public static bool IsValidMove(Playfield playfield, Directions nextDirection)
        {
            int playerCurrentRow = playfield.PlayerPosition.row;
            int playerCurrentCol = playfield.PlayerPosition.col;
            Position playerCurrentPosition = new Position(playerCurrentRow, playerCurrentCol);
            
            if (playerCurrentPosition.isWinning())
            {
                return false;
            }
            playerCurrentPosition.move(nextDirection);

            int[,] fieldGrid = playfield.LabyrinthGrid;
            return IsValidPosition(fieldGrid, playerCurrentPosition);
        }

        private static bool IsValidPosition(int[,] fieldGrid, Position currentPosition)
        {
            return fieldGrid[currentPosition.row, currentPosition.col] == 0 && currentPosition.isValidPosition();
        }
    }
}
