namespace Instant.Training.UI.Services
{
    using System.IO;

    using Instant.Training.UI.Services.Interfaces;

    public class PathService : IPathService
    {
        private readonly string _steamPath;

        public PathService(ISteamService steamService)
        {
            _steamPath = steamService.GetSteamGamesPath();
        }

        public string RocketLeaguePath => Path.Combine(_steamPath, Constants.Steam.RocketLeaguePath);

        public string BakkesModPath => Path.Combine(RocketLeaguePath, Constants.Steam.BakkesModPath);

        public string ModDllPath => Path.Combine(BakkesModPath, Constants.Steam.PluginsDirectory, Constants.DllName);

        public string PluginsConfigFilePath => Path.Combine(BakkesModPath, Constants.Steam.PluginsConfigFile);
    }
}