namespace TeamTellurium.Labyrinth
{
    using System;

    public class ConsoleInput : IConsoleInput
    {
        public event EventHandler OnWriteTop;
        public event EventHandler OnWriteRestart;
        public event EventHandler OnWriteExit;
        public event EventHandler OnWriteL;
        public event EventHandler OnWriteR;
        public event EventHandler OnWriteU;
        public event EventHandler OnWriteD;
        
        public void ProcessInput(string input)
        {
            if (input == "top")
            {
                if (this.OnWriteTop != null)
                {
                    this.OnWriteTop(this, new EventArgs());
                }
            }
            else if (input == "restart")
            {
                if (this.OnWriteRestart != null)
                {
                    this.OnWriteRestart(this, new EventArgs());
                }
            }
            else if (input == "L")
            {
                if (this.OnWriteL != null)
                {
                    this.OnWriteL(this, new EventArgs());
                }
            }
            else if (input == "R")
            {
                if (this.OnWriteR != null)
                {
                    this.OnWriteR(this, new EventArgs());
                }
            }
            else if (input == "U")
            {
                if (this.OnWriteU != null)
                {
                    this.OnWriteU(this, new EventArgs());
                }
            }
            else if (input == "D")
            {
                if (this.OnWriteD != null)
                {
                    this.OnWriteD(this, new EventArgs());
                }
            }
            else if (input == "exit")
            {
                if (this.OnWriteExit != null)
                {
                    this.OnWriteExit(this, new EventArgs());
                }
            }
        }
    }
}