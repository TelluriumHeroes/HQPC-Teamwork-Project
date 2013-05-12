using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace TeamTellurium.Labyrinth
{
    public class LabyrinthMain
    {
        public static void Main(string[] args)
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);
            HandleMoveEvents(engine, engine.UserInput);
            engine.Run();
        }

        public static void HandleMoveEvents(GameEngine engine, ConsoleInput movement)
        {
            movement.OnWriteL += (sender, eventInfo) =>
            {
                engine.MoveAtDirection(Directions.Left, engine.MoveLeft);
            };

            movement.OnWriteR += (sender, eventInfo) =>
            {
                engine.MoveAtDirection(Directions.Right, engine.MoveRight);
            };

            movement.OnWriteU += (sender, eventInfo) =>
            {
                engine.MoveAtDirection(Directions.Up, engine.MoveUp);
            };

            movement.OnWriteD += (sender, eventInfo) =>
            {
                engine.MoveAtDirection(Directions.Down, engine.MoveDown);
            };

            movement.OnWriteTop += (sender, eventInfo) =>
            {
                engine.ShowTopResults();
            };

            movement.OnWriteRestart += (sender, eventInfo) =>
            {
                engine.InitializeNewGame();
            };

            movement.OnWriteExit += (sender, eventInfo) =>
            {
                engine.QuitGame();
            };
        }
    }

    public class Message
    {
        public void Invalid()
        {
            Console.WriteLine("* Invalid move!");
        }
        public void move()
        {
            Console.Write("Enter your move (L=left, R=right, U=up, D=down): ");
        }

        public void intro()
        {
            Console.WriteLine("Welcome to \"Labyrinth\" game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
        }
        public void nl()
        {
            Console.WriteLine();
        }
        public void win(int moves)
        {
            Console.Write("Congratulations! You escaped in {0} moves!\nPlease enter your name for the top scoreboard: ", moves);



        }
        public void playing()
        {
            Console.WriteLine("You are playing \"Labyrinth\" game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
        }
    }

    public class Position
    {
        public int row;
        public int col;
        public Position()
        {
            this.row = 3;
            this.col = 3;
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
