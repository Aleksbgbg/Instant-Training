namespace Instant.Training.UI.Utilities
{
    using System;
    using System.Diagnostics;

    public class ProcessAdapter : IProcess
    {
        private readonly Process _process;

        public ProcessAdapter(Process process)
        {
            _process = process;
        }

        public event EventHandler Exited
        {
            add => _process.Exited += value;

            remove => _process.Exited -= value;
        }

        public void Kill()
        {
            _process.Kill();
        }
    }
}