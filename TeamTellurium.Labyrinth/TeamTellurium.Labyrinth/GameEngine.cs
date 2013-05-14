using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

            while (!this.HasGameQuit)
            {
                this.UserInput.ProcessInput();

                RenderAll();

                if (Playfield.IsVictory())
                {
                    this.OnGameOver();
                }

                if (this.HasGameQuit)
                {
                    Console.WriteLine("Good Bye!");
                    Console.ReadKey();
                }
            }
        }

        public void InitializeNewGame()
        {
            this.Score = 0;
            Playfield.InitializeField();
            RenderAll();
        }

        private void RenderAll()
        {
            Renderer.ResetField();
            Renderer.RenderInfo(this.Messages);
            Renderer.RenderField(this.Playfield);
        }

        public void ShowTopResults()
        {
            Renderer.RenderScoreboard(this.Scoreboard.ShowScoreboard().ToString());
            Console.WriteLine("Press Any Key To Continue.");
            Console.ReadKey();
        }

        public void MoveAtDirection(Directions direction, Action MovementAction)
        {
            if (MovesChecker.IsValidMove(Playfield, direction))
            {
                this.Score++;
                MovementAction();
            }
            else
            {   
                Console.WriteLine(Messages.InvalidMoveMessage());
                Thread.Sleep(500);
            }
        }

        public void MoveLeft()
        {
            Playfield.PlayerPosition.MoveAtDirection(Directions.Left);
        }

        public void MoveRight()
        {
            Playfield.PlayerPosition.MoveAtDirection(Directions.Right);
        }

        public void MoveUp()
        {
            Playfield.PlayerPosition.MoveAtDirection(Directions.Up);
        }

        public void MoveDown()
        {
            Playfield.PlayerPosition.MoveAtDirection(Directions.Down);
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
                Renderer.RenderWinInfo(this.Messages, this.Score);
                name = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(name));
            this.Scoreboard.AddPlayerInScoreboard(name, this.Score);

            this.Messages.NewLine();
            this.InitializeNewGame();
        }
    }
}
