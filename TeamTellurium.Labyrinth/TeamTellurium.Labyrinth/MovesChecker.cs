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

            playerCurrentPosition.MoveAtDirection(nextDirection);

            int[,] fieldGrid = playfield.LabyrinthGrid;
            return IsValidPosition(fieldGrid, playerCurrentPosition);
        }

        private static bool IsValidPosition(int[,] fieldGrid, Position currentPosition)
        {
            int rows = fieldGrid.GetLength(0);
            int cols = fieldGrid.GetLength(1);
            bool isRowInRange = (currentPosition.Row <= rows && currentPosition.Row >= 0);
            bool isColInRange = (currentPosition.Col >= 0 && currentPosition.Col <= cols);
            bool isCellEmpty = fieldGrid[currentPosition.Row, currentPosition.Col] == 0;

            return isCellEmpty && (isRowInRange && isColInRange);
        }
    }
}
