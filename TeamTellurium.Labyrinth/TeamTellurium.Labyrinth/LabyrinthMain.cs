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
}
