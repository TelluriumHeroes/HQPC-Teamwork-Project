namespace TeamTellurium.Labyrinth
{
    using System;
    using System.Linq;
    using System.Text;

    public class LabyrinthMain
    {
        public static void Main(string[] args)
        {
            Playfield playfield = new Playfield();
            GameEngine engine = new GameEngine(playfield);
            AssignEvents(engine, engine.UserInput);
            engine.Run();
        }

        public static void AssignEvents(GameEngine engine, ConsoleInput movement)
        {
            movement.OnWriteL += (sender, eventInfo) =>
            {
                engine.MoveAtDirection(Direction.Left, engine.MoveLeft);
            };

            movement.OnWriteR += (sender, eventInfo) =>
            {
                engine.MoveAtDirection(Direction.Right, engine.MoveRight);
            };

            movement.OnWriteU += (sender, eventInfo) =>
            {
                engine.MoveAtDirection(Direction.Up, engine.MoveUp);
            };

            movement.OnWriteD += (sender, eventInfo) =>
            {
                engine.MoveAtDirection(Direction.Down, engine.MoveDown);
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
}
