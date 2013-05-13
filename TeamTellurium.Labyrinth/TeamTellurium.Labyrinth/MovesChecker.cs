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
            int playerCurrentRow = playfield.PlayerPosition.Row;
            int playerCurrentCol = playfield.PlayerPosition.Col;
            Position playerCurrentPosition = new Position(playerCurrentRow, playerCurrentCol);
            
            if (playerCurrentPosition.IsWinner())
            {
                return false;
            }
            playerCurrentPosition.IsMoved(nextDirection);

            int[,] fieldGrid = playfield.LabyrinthGrid;
            return IsValidPosition(fieldGrid, playerCurrentPosition);
        }

        private static bool IsValidPosition(int[,] fieldGrid, Position currentPosition)
        {
            return fieldGrid[currentPosition.Row, currentPosition.Col] == 0 && currentPosition.IsValidPosition();
        }
    }
}
