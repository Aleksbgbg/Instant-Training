namespace Instant.Training.UI.Services.Interfaces
{
    public interface IPathService
    {
        string RocketLeaguePath { get; }

        string BakkesModPath { get; }

        string ModDllPath { get; }

        string PluginsConfigFilePath { get; }

        string DllResourcePath { get; }

        string BakkesModInjectorResourcePath { get; }
    }
}