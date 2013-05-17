namespace TeamTellurium.Labyrinth
{
    using System;

    public class Messages
    {
        public string InvalidMoveMessage()
        {
            string invalidMove = "Invalid move!";
            return invalidMove;
        }

        public string MoveInstructionsMessage()
        {
            string moveInstructions = "Enter your move (L=left, R=right, U=up, D=down): ";
            return moveInstructions;
        }

        public string WelcomeMessage()
        {
            string welcomeMessage = "Welcome to \"Labyrinth\" game.\r\nPlease try to escape.\r\nUse 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.";
            return welcomeMessage;
        }

        public string NewLine()
        {
            return Environment.NewLine;
        }

        public string WinnerCongratsMessage(int moves)
        {
            string congratulationsMessage = "Congratulations! You escaped in " + moves + " moves!\nPlease enter your name for the top scoreboard: ";
            return congratulationsMessage;
        }

        public string PlayingInstructionsMessage()
        {
            string playInstructions = "You are playing \"Labyrinth\" game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.";
            return playInstructions;
        }
    }
}