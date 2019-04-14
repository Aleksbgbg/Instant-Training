namespace Instant.Training.UI.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Instant.Training.UI.Services.Interfaces;
    using Instant.Training.UI.Utilities;

    public class SetupService : ISetupService
    {
        private readonly IPathService _pathService;

        private readonly IFileSystemProvider _fileSystemProvider;

        private readonly IHashProvider _hashProvider;

        private readonly IProcessProvider _processProvider;

        private readonly IFileWatchProvider _fileWatchProvider;

        public SetupService(IPathService pathService, IFileSystemProvider fileSystemProvider, IHashProvider hashProvider, IProcessProvider processProvider, IFileWatchProvider fileWatchProvider)
        {
            _pathService = pathService;
            _fileSystemProvider = fileSystemProvider;
            _hashProvider = hashProvider;
            _processProvider = processProvider;
            _fileWatchProvider = fileWatchProvider;
        }

        public bool CheckRocketLeagueInstalled()
        {
            return _fileSystemProvider.DirectoryExists(_pathService.RocketLeaguePath);
        }

        public bool CheckBakkesModInstalled()
        {
            return _fileSystemProvider.DirectoryExists(_pathService.BakkesModPath);
        }

        public async Task InstallBakkesMod()
        {
            IProcess bakkesModInjectorProcess;

            void StartBakkesModInjector()
            {
                bakkesModInjectorProcess = _processProvider.StartProcess(_pathService.BakkesModInjectorResourcePath);
                bakkesModInjectorProcess.Exited += OnBakkesModInjectorExited;
            }

            void OnBakkesModInjectorExited(object sender, EventArgs e)
            {
                bakkesModInjectorProcess.Exited -= OnBakkesModInjectorExited;
                StartBakkesModInjector();
            }

            StartBakkesModInjector();

            await _fileWatchProvider.DirectoryCreated(_pathService.BakkesModPath);

            bakkesModInjectorProcess.Exited -= OnBakkesModInjectorExited;
            bakkesModInjectorProcess.Kill();
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