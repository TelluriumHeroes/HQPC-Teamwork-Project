namespace TeamTellurium.Labyrinth
{
    using System;

    public interface IConsoleInput
    {
        event EventHandler OnWriteL;
        event EventHandler OnWriteR;
        event EventHandler OnWriteU;
        event EventHandler OnWriteD;
        void ProcessInput(string input);
    }
}