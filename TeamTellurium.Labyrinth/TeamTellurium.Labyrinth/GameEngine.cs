using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTellurium.Labyrinth
{
    public class GameEngine
    {
        public ConsoleInput UserInput { get; private set; }
        private Playfield Playfield { get; set; }
        private Messages Messages { get; set; }
        private ScoreBoard Scoreboard { get; set; }
        private int Score { get; set; }
        private bool HasGameQuit { get; set; }

        public GameEngine(Playfield playfield)
        {
            this.Playfield = playfield;
            this.UserInput = new ConsoleInput();
            this.Messages = new Messages();
            this.Scoreboard = new ScoreBoard();
            this.Score = 0;
        }

        public void Run()
        {
            this.InitializeNewGame();

            Console.WriteLine(Messages.MoveInstructions());

            while (!this.HasGameQuit)
            {
                this.UserInput.ProcessInput();

                if (Playfield.IsWinning())
                {
                    Console.Clear();
                    Console.WriteLine(this.Messages.WelcomeMessage());
                    Renderer.RenderField(this.Playfield);
                    this.OnGameOver();
                }

                if (!this.HasGameQuit)
                {
                    Console.Clear();
                    Console.WriteLine(this.Messages.WelcomeMessage());
                    Messages.NewLine();
                    Renderer.RenderField(this.Playfield);
                    Console.WriteLine(this.Messages.MoveInstructions());
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
            Console.WriteLine(Messages.WelcomeMessage());
            Playfield.InitializeField();
            Messages.NewLine();
            Renderer.RenderField(Playfield);
            this.Score = 0;
        }

        public void ShowTopResults()
        {
            Renderer.RenderScoreboard(this.Scoreboard.ShowScoreboard().ToString());
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
                Console.WriteLine(Messages.InvalidMove());
            }
        }

        public void MoveLeft()
        {
            Playfield.PlayerPosition.IsMoved(Directions.Left);
        }

        public void MoveRight()
        {
            Playfield.PlayerPosition.IsMoved(Directions.Right);
        }

        public void MoveUp()
        {
            Playfield.PlayerPosition.IsMoved(Directions.Up);
        }

        public void MoveDown()
        {
            Playfield.PlayerPosition.IsMoved(Directions.Down);
        }

        public void QuitGame()
        {
            this.HasGameQuit = true;
        }

        private void OnGameOver()
        {
            string name;
            do
            {
                Console.WriteLine(Messages.WinnerCongratsMessage(this.Score));
                name = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(name));
            this.Scoreboard.AddPlayerInScoreboard(name, this.Score);

            this.Messages.NewLine();
            this.InitializeNewGame();
        }
    }
}
