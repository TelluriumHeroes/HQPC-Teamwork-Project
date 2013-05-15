using System;
using System.Threading;

namespace TeamTellurium.Labyrinth
{
    public class GameEngine
    {
        public ConsoleInput UserInput { get; private set; }
        private Playfield Playfield { get; set; }
        private Messages Messages { get; set; }
        private ScoreBoard Scoreboard { get; set; }
        
        public int Score { get; private set; }
        public bool HasGameQuit { get; private set; }

        public GameEngine(Playfield playfield)
        {
            this.Playfield = playfield;
            this.UserInput = new ConsoleInput();
            this.Messages = new Messages();
            this.Scoreboard = new ScoreBoard();
            this.Score = 0;
            this.HasGameQuit = false;
        }

        public void Run()
        {
            this.InitializeNewGame();

            while (!this.HasGameQuit)
            {
                string input = Console.ReadLine();
                this.UserInput.ProcessInput(input);

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
            this.Playfield.InitializeField();
            RenderAll();
        }

        private void RenderAll()
        {
            Renderer.ResetField();

            string welcomeMessage = this.Messages.WelcomeMessage();
            string moveInstructionsMessage = this.Messages.MoveInstructionsMessage();
            Renderer.RenderInfo(welcomeMessage, moveInstructionsMessage);
            Renderer.RenderField(this.Playfield.LabyrinthGrid, this.Playfield.PlayerPosition.Row, this.Playfield.PlayerPosition.Col);
        }

        public void ShowTopResults()
        {
            Renderer.RenderScoreboard(GetTopResults());
            Console.WriteLine("Press Any Key To Continue.");
            Console.ReadKey();
        }

        public string GetTopResults()
        {
            return this.Scoreboard.ShowScoreboard().ToString();
        }

        private void OnGameOver()
        {
            string name;
            do
            {
                Renderer.RenderWinInfo(this.Messages.WinnerCongratsMessage(this.Score));
                name = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(name));

            this.Scoreboard.AddPlayerInScoreboard(name, this.Score);
            this.InitializeNewGame();
        }

        public void MoveAtDirection(Direction direction, Action MovementAction)
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
            Playfield.PlayerPosition.MoveAtDirection(Direction.Left);
        }

        public void MoveRight()
        {
            Playfield.PlayerPosition.MoveAtDirection(Direction.Right);
        }

        public void MoveUp()
        {
            Playfield.PlayerPosition.MoveAtDirection(Direction.Up);
        }

        public void MoveDown()
        {
            Playfield.PlayerPosition.MoveAtDirection(Direction.Down);
        }

        public void QuitGame()
        {
            this.HasGameQuit = true;
        }
    }
}
