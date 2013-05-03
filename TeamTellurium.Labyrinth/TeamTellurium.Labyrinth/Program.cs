using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace TeamTellurium.Labyrinth
{
    public enum Direction { Blank = -1, Left, Up, Right, Down };

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
        public int x;
        public int y;
        public Position()
        {
            this.x = 3;
            this.y = 3;
        }
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool move(Direction direction)
        {
            if (isWinning()) return false;
            switch (direction)
            {
                case Direction.Left:
                    this.x -= 1;
                    break;
                case Direction.Up:
                    this.y -= 1;
                    break;
                case Direction.Right:
                    this.x += 1;
                    break;
                case Direction.Down:
                    this.y += 1;
                    break;
                default:
                    return false;
            }
            return true;
        }

        public bool isWinning()
        {
            bool resault;
            resault = false;
            if (x == 0 || x == 6 || y == 0 || y == 6)
                resault = true;
            return resault;
        }



        public bool isValidPosition()
        {
            if (x <= 6 && x >= 0 && y >= 0 && y <= 6) return true;
            else return false;
        }

        public void makeStarting()
        {
            this.x = 3;
            this.y = 3;
        }
    }

    

    public class Scoreboard
    {
        void create()
        {
            FileInfo file = new FileInfo("scoreboard");
            FileStream stream = file.Open(FileMode.OpenOrCreate, FileAccess.Read);
            stream.Close();
        }
        public void pokazvane()
        {
            create();
            FileInfo file = new FileInfo("scoreboard");
            StreamReader fileReader = file.OpenText();
            string line = null;
            bool isEmpty = true;
            int i = 0;
            while ((line = fileReader.ReadLine()) != null)
            {
                isEmpty = false;
                string[] nameAndScore = line.Split();
                Console.WriteLine("{0}: {1}->{2}", ++i,nameAndScore[0], nameAndScore[1] );
            }

            if (isEmpty) Console.WriteLine("Scoreboard is empty.");
            fileReader.Close();
        }
        
        public void add(string name, int score)
        {
            create(); 
            
            FileInfo file = new FileInfo("scoreboard");
            StreamReader fileReader = file.OpenText();
            String line=null;
            int index = 0;
            int[] scores = new int[5];
            string[] names = new string[5];
            while ((line = fileReader.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split();
                scores[index] = Int32.Parse(nameAndScore[1]);
                names[index++] = nameAndScore[0];
            }
            if (index < 5)
            {
                scores[index] = score;
                names[index] = name;
            }
            else
            if (score < scores[index - 1])
            {
                scores[index - 1] = score;
                names[index - 1] = name;
            }
            if (index == 5) index = 4;
            for (int i = 0; i <= index-1; i++)
            for(int j=i+1;j<=index;j++)
                if (scores[i] > scores[j])
                {
                    int swapValue = scores[i];
                    scores[i] = scores[j];
                    scores[j] = swapValue;
                    string swapValueString = names[i];
                    names[i] = names[j];
                    names[j] = swapValueString;
                }
            fileReader.Close();
            StreamWriter fileWriter = file.CreateText();
            for(int i=0;i<=index;i++)
            fileWriter.WriteLine("{0} {1}", names[i], scores[i],i+1);
            fileWriter.Close();
        }
    }

    public class Program
    {
        static Playfield playfield = new Playfield();
        static Message message = new Message();
        static Scoreboard scores;
        static int moves = 0;

        static void newGame()
        {
            message.intro();
            playfield.InitializeField();
            message.nl();
            Render.RenderField(playfield.LabyrinthGrid, playfield.Player);
            moves = 0;
        }

        static void Main(string[] args)
        {

            newGame();
            scores=new Scoreboard();
            String input = "";
            message.move();
            while ((input = Console.ReadLine()) != "exit")
            {   
                switch (input)
                {
                    case "top":
                        scores.pokazvane();
                        break;
                    case "restart":
                        newGame();
                        break;
                    case "L":

                        if (!playfield.TryMove(Direction.Left)) message.Invalid();
                        else
                        {
                            moves++;
                            Render.RenderField(playfield.LabyrinthGrid, playfield.Player);
                        }

                        break;
                    case "U":

                        if (!playfield.TryMove(Direction.Up)) message.Invalid();
                        else
                        {
                            moves++;
                            Render.RenderField(playfield.LabyrinthGrid, playfield.Player);
                        }

                        break;
                    case "R":

                        if (!playfield.TryMove(Direction.Right)) message.Invalid();
                        else
                        {
                            moves++;
                            Render.RenderField(playfield.LabyrinthGrid, playfield.Player);
                        }

                        break;
                    case "D":

                        if (!playfield.TryMove(Direction.Down)) message.Invalid();
                        else
                        {
                            moves++;
                            Render.RenderField(playfield.LabyrinthGrid, playfield.Player);
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
                        scores.add(name, moves);
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
