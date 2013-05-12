using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTellurium.Labyrinth
{
    public class GameEngine
    {
        private Playfield Playfield { get; set; }
        public ConsoleInput UserInput { get; private set; }
        private Message Messages { get; set; }
        private ScoreBoard Scoreboard { get; set; }
        private int Score { get; set; }
        private bool HasGameQuit { get; set; }

        public GameEngine(Playfield playfield)
        {
            this.Playfield = playfield;
            this.UserInput = new ConsoleInput();
            this.Messages = new Message();
            this.Scoreboard = new ScoreBoard();
            this.Score = 0;
        }

        public void Run()
        {   
            InitializeNewGame();

            Messages.move();

            while (!this.HasGameQuit)
            {   
                UserInput.ProcessInput();

                if (Playfield.IsWinning())
                {
                    Console.Clear();
                    this.Messages.intro();
                    Renderer.RenderField(this.Playfield);
                    OnGameOver();
                    
                }

                if (!this.HasGameQuit)
                {
                    Console.Clear();
                    this.Messages.intro();
                    Console.WriteLine();

                    Renderer.RenderField(this.Playfield);
                    this.Messages.move();    
                }
               
                else
                {
                    Console.WriteLine("Good Bye!");
                    Console.ReadKey();
                }
                
            }
        }

        public void InitializeNewGame()
        {
            Messages.intro();
            Playfield.InitializeField();
            Messages.nl();
            Renderer.RenderField(Playfield);
            this.Score = 0;
        }

        private void OnGameOver()
        {
            string name;
            do
            {
                Messages.win(this.Score);
                name = Console.ReadLine();
            } while (string.IsNullOrEmpty(name));
            Scoreboard.AddPlayerInScoreboard(name, Score);

            this.Messages.nl();
            InitializeNewGame();
        }

        public void ShowTopResults()
        {
            Renderer.RenderScoreboard(Scoreboard.ShowScoreboard().ToString());
            Console.WriteLine("Press Any Key To Continue.");
            Console.ReadKey();
        }

        public void MoveAtDirection(Directions direction, Action movementAction)
        {
            if (MovesChecker.IsValidMove(Playfield, direction))
            {
                this.Score++;
                movementAction();
            }
            else
            {
                Messages.Invalid();
            }
        }

        public void MoveLeft()
        {
            Playfield.PlayerPosition.move(Directions.Left);
        }

        public void MoveRight()
        {
            Playfield.PlayerPosition.move(Directions.Right);
        }

        public void MoveUp()
        {
            Playfield.PlayerPosition.move(Directions.Up);
        }

        public void MoveDown()
        {
            Playfield.PlayerPosition.move(Directions.Down);
        }

        public void QuitGame()
        {
            this.HasGameQuit = true;
        }
    }
}
