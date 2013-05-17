namespace TeamTellurium.Labyrinth
{
    using System;

    public class ConsoleInput : IConsoleInput
    {
        private const string COMMAND_TOP = "top";
        private const string COMMAND_RESTART = "restart";
        private const string COMMAND_EXIT = "exit";
        private const string COMMAND_LEFT = "L";
        private const string COMMAND_RIGHT = "R";
        private const string COMMAND_DOWN = "D";
        private const string COMMAND_UP = "U";

        public event EventHandler OnWriteTop;
        public event EventHandler OnWriteRestart;
        public event EventHandler OnWriteExit;
        public event EventHandler OnWriteL;
        public event EventHandler OnWriteR;
        public event EventHandler OnWriteU;
        public event EventHandler OnWriteD;
        
        public void ProcessInput(string input)
        {
            if (input == COMMAND_TOP)
            {
                if (this.OnWriteTop != null)
                {
                    this.OnWriteTop(this, new EventArgs());
                }
            }
            else if (input == COMMAND_RESTART)
            {
                if (this.OnWriteRestart != null)
                {
                    this.OnWriteRestart(this, new EventArgs());
                }
            }
            else if (input == COMMAND_LEFT)
            {
                if (this.OnWriteL != null)
                {
                    this.OnWriteL(this, new EventArgs());
                }
            }
            else if (input == COMMAND_RIGHT)
            {
                if (this.OnWriteR != null)
                {
                    this.OnWriteR(this, new EventArgs());
                }
            }
            else if (input == COMMAND_UP)
            {
                if (this.OnWriteU != null)
                {
                    this.OnWriteU(this, new EventArgs());
                }
            }
            else if (input == COMMAND_DOWN)
            {
                if (this.OnWriteD != null)
                {
                    this.OnWriteD(this, new EventArgs());
                }
            }
            else if (input == COMMAND_EXIT)
            {
                if (this.OnWriteExit != null)
                {
                    this.OnWriteExit(this, new EventArgs());
                }
            }
        }
    }
}