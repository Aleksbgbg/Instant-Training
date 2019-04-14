namespace Instant.Training.UI.Utilities
{
    using System;

    public interface IProcess
    {
        event EventHandler Exited;

        void Kill();
    }
}