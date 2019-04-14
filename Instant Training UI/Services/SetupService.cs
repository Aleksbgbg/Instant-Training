namespace Instant.Training.UI.Services
{
    using System;
    using System.IO;
    using System.Linq;

    using Instant.Training.UI.Services.Interfaces;
    using Instant.Training.UI.Utilities;

    public class SetupService : ISetupService
    {
        private readonly ISteamService _steamService;

        private readonly IFileSystemProvider _fileSystemProvider;

        public SetupService(ISteamService steamService, IFileSystemProvider fileSystemProvider)
        {
            _steamService = steamService;
            _fileSystemProvider = fileSystemProvider;
        }

        public bool CheckRocketLeagueInstalled()
        {
            string rocketLeaguePath = GetRocketLeaguePath();
            return _fileSystemProvider.DirectoryExists(rocketLeaguePath);
        }

        public bool CheckBakkesModInstalled()
        {
            string bakkesModPath = GetBakkesModPath();
            return _fileSystemProvider.DirectoryExists(bakkesModPath);
        }

        public void SetupPlugin()
        {
            EnsurePluginDllInstalled();
            EnsurePluginLoadsOnStart();
        }

        private void EnsurePluginDllInstalled()
        {
            string pluginsPath = GetPluginsPath();
            string instantTrainingDllPath = Path.Combine(pluginsPath, Constants.DllName);

            if (!_fileSystemProvider.FileExists(instantTrainingDllPath))
            {
                string dllResource = Path.Combine(_fileSystemProvider.CurrentDirectory, Constants.ResourcesDirectory, Constants.DllName);
                _fileSystemProvider.Copy(dllResource, instantTrainingDllPath);
            }
        }

        private void EnsurePluginLoadsOnStart()
        {
            string configFilePath = GetConfigPluginsFile();
            string configFileContents = _fileSystemProvider.ReadFile(configFilePath);

            string[] configLines = configFileContents.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            string loadPluginCommand = $"plugin load {Constants.PluginName}";

            if (configLines.All(line => line != loadPluginCommand))
            {
                _fileSystemProvider.WriteFile(configFilePath, string.Join(Environment.NewLine, configLines.Append(loadPluginCommand)));
            }
        }

        private string GetConfigPluginsFile()
        {
            return Path.Combine(GetBakkesModPath(), Constants.Steam.LoadPluginsFile);
        }

        private string GetPluginsPath()
        {
            return Path.Combine(GetBakkesModPath(), Constants.Steam.PluginsDirectory);
        }

        private string GetBakkesModPath()
        {
            return Path.Combine(GetRocketLeaguePath(), Constants.Steam.BakkesModPath);
        }

        private string GetRocketLeaguePath()
        {
            return Path.Combine(_steamService.GetSteamGamesPath(), Constants.Steam.RocketLeaguePath);
        }

        private string GetAppResourcesDirectory()
        {
            return Path.Combine(_fileSystemProvider.CurrentDirectory, Constants.ResourcesDirectory);
        }
    }
}