namespace Instant.Training.UI.Services
{
    using System.IO;

    using Instant.Training.UI.Services.Interfaces;
    using Instant.Training.UI.Utilities;

    public class PathService : IPathService
    {
        private readonly IFileSystemProvider _fileSystemProvider;

        private readonly string _steamPath;

        public PathService(IFileSystemProvider fileSystemProvider, ISteamService steamService)
        {
            _fileSystemProvider = fileSystemProvider;
            _steamPath = steamService.GetSteamGamesPath();
        }

        public string RocketLeaguePath => Path.Combine(_steamPath, Constants.Steam.RocketLeaguePath);

        public string BakkesModPath => Path.Combine(RocketLeaguePath, Constants.Steam.BakkesModPath);

        public string ModDllPath => Path.Combine(BakkesModPath, Constants.Steam.PluginsDirectory, Constants.DllName);

        public string PluginsConfigFilePath => Path.Combine(BakkesModPath, Constants.Steam.PluginsConfigFile);

        public string DllResourcePath => Path.Combine(_fileSystemProvider.CurrentDirectory, Constants.ResourcesDirectory, Constants.DllName);

        public string BakkesModInjectorResourcePath => Path.Combine(_fileSystemProvider.CurrentDirectory, Constants.ResourcesDirectory, Constants.BakkesModInjectorFile);
    }
}