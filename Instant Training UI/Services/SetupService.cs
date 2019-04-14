namespace Instant.Training.UI.Services
{
    using System;
    using System.Linq;

    using Instant.Training.UI.Services.Interfaces;
    using Instant.Training.UI.Utilities;

    public class SetupService : ISetupService
    {
        private readonly IPathService _pathService;

        private readonly IFileSystemProvider _fileSystemProvider;

        private readonly IHashProvider _hashProvider;

        public SetupService(IPathService pathService, IFileSystemProvider fileSystemProvider, IHashProvider hashProvider)
        {
            _pathService = pathService;
            _fileSystemProvider = fileSystemProvider;
            _hashProvider = hashProvider;
        }

        public bool CheckRocketLeagueInstalled()
        {
            return _fileSystemProvider.DirectoryExists(_pathService.RocketLeaguePath);
        }

        public bool CheckBakkesModInstalled()
        {
            return _fileSystemProvider.DirectoryExists(_pathService.BakkesModPath);
        }

        public bool CheckModDllInstalled()
        {
            return _fileSystemProvider.FileExists(_pathService.ModDllPath) &&
                   _hashProvider.Hash(_fileSystemProvider.ReadFileBytes(_pathService.ModDllPath)) == _hashProvider.Hash(_fileSystemProvider.ReadFileBytes(_pathService.DllResourcePath));
        }

        public void InstallModDll()
        {
            _fileSystemProvider.Copy(_pathService.DllResourcePath, _pathService.ModDllPath);
        }

        public bool CheckPluginLoadsOnStartup()
        {
            string pluginConfig = _fileSystemProvider.ReadFile(_pathService.PluginsConfigFilePath);

            return pluginConfig.Split(new string[] { "\r\n" }, StringSplitOptions.None)
                               .Contains(ComputePluginLoadCommand());
        }

        public void LoadPluginOnStartup()
        {
            _fileSystemProvider.AppendFile(_pathService.PluginsConfigFilePath, ComputePluginLoadCommand());
        }

        private static string ComputePluginLoadCommand()
        {
            return $"plugin load {Constants.PluginName}";
        }
    }
}