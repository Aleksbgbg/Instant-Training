namespace Instant.Training.UI.Utilities
{
    using System.Diagnostics;

    public class ProcessProvider : IProcessProvider
    {
        public IProcess StartProcess(string process)
        {
            return new ProcessAdapter(Process.Start(process));
        }
    }
}