using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace TeamTellurium.Labyrinth
{
    

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

 
    public class Program
    {
        static Playfield playfield = new Playfield();
        static Message message = new Message();
        static ScoreBoard scores;
        static int moves = 0;

        static void newGame()
        {
            message.intro();
            playfield.InitializeField();
            message.nl();
            Renderer.RenderField(playfield);
            moves = 0;
        }

        static void Main(string[] args)
        {
            newGame();
            scores=new ScoreBoard();
            String input = "";
            message.move();

            while ((input = Console.ReadLine()) != "exit")
            {   
                switch (input)
                {
                    case "top":
                        //scores.ShowScoreboard();
                        Renderer.RenderScoreboard(scores.ShowScoreboard().ToString());
                        break;
                    case "restart":
                        newGame();
                        break;
                    case "L":

                        if (!MovesChecker.IsValidMove(playfield, Directions.Left)) message.Invalid();
                        else
                        {
                            moves++;
                            playfield.PlayerPosition.move(Directions.Left);
                            Renderer.RenderField(playfield);
                        }

                        break;
                    case "U":

                        if (!MovesChecker.IsValidMove(playfield, Directions.Up)) message.Invalid();
                        else
                        {
                            moves++;
                            playfield.PlayerPosition.move(Directions.Up);
                            Renderer.RenderField(playfield);
                        }

                        break;
                    case "R":

                        if (!MovesChecker.IsValidMove(playfield, Directions.Right)) message.Invalid();
                        else
                        {
                            moves++;
                            playfield.PlayerPosition.move(Directions.Right);
                            Renderer.RenderField(playfield);
                        }

                        break;
                    case "D":

                        if (!MovesChecker.IsValidMove(playfield, Directions.Down)) message.Invalid();
                        else
                        {
                            moves++;
                            playfield.PlayerPosition.move(Directions.Down);
                            Renderer.RenderField(playfield);
                        }

                        break;
                    default:
                        {
                            message.Invalid();
                            break;
                        }

                }


                

                if (playfield.IsWinning())
                {
                   
                    message.win(moves);
                    string name = Console.ReadLine();
                    try
                    {
                        scores.AddPlayerInScoreboard(name, moves);
                    }
                    finally
                    {

                    };
                    message.nl();
                    newGame();
                }
                message.move();
            }
            Console.Write("Good Bye!");
            Console.ReadKey();
        }
    }
}
