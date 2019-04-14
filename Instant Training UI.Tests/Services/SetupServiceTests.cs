namespace Instant.Training.UI.Tests.Services
{
    using System;
    using System.IO;

    using Instant.Training.UI.Services;
    using Instant.Training.UI.Services.Interfaces;
    using Instant.Training.UI.Utilities;

    using Moq;

    using Xunit;

    public class SetupServiceTests
    {
        private const string SteamGamesPath = @"Z:\Steam";

        private readonly Mock<ISteamService> _steamServiceMock;

        private readonly Mock<IFileSystemProvider> _fileSystemProviderMock;

        private readonly SetupService _setupService;

        public SetupServiceTests()
        {
            _steamServiceMock = new Mock<ISteamService>();
            _steamServiceMock.Setup(steamService => steamService.GetSteamGamesPath())
                             .Returns(SteamGamesPath);

            _fileSystemProviderMock = new Mock<IFileSystemProvider>();

            _setupService = new SetupService(_steamServiceMock.Object, _fileSystemProviderMock.Object);
        }

        [Fact]
        public void TestRocketLeagueInstalledChecksSteamPath()
        {
            string rocketLeaguePath = Path.Combine(SteamGamesPath, Constants.Steam.RocketLeaguePath);
            SetupDirectoryExists(rocketLeaguePath);

            bool rocketLeagueInstalled = _setupService.CheckRocketLeagueInstalled();

            VerifyQueryDirectoryExists(rocketLeaguePath);
            Assert.True(rocketLeagueInstalled);
        }

        [Fact]
        public void TestBakkesModInstalledChecksSteamPath()
        {
            string bakkesModPath = Path.Combine(SteamGamesPath, Constants.Steam.RocketLeaguePath, Constants.Steam.BakkesModPath);
            SetupDirectoryExists(bakkesModPath);

            bool bakkesModInstalled = _setupService.CheckBakkesModInstalled();

            VerifyQueryDirectoryExists(bakkesModPath);
            Assert.True(bakkesModInstalled);
        }

        [Fact]
        public void TestSetupPluginTestsIfDllExists()
        {
            SetupConfigFileWithPlugin();
            string dllPath = SetupDllTargetPathExists();

            _setupService.SetupPlugin();

            VerifyQueryFileExists(dllPath);
        }

        [Fact]
        public void TestSetupDoesNotCopyPluginWhenExists()
        {
            SetupConfigFileWithPlugin();
            string dllResourcePath = SetupDllResourcePath();
            string dllTargetPath = SetupDllTargetPathExists();

            _setupService.SetupPlugin();

            VerifyQueryFileExists(dllTargetPath);
            VerifyCopyFile(dllResourcePath, dllTargetPath, Times.Never);
        }

        [Fact]
        public void TestSetupCopiesPluginWhenNotExist()
        {
            SetupConfigFileWithPlugin();
            string dllResourcePath = SetupDllResourcePath();
            string dllTargetPath = SetupDllTargetPathMissing();

            _setupService.SetupPlugin();

            VerifyQueryFileExists(dllTargetPath);
            VerifyCopyFile(dllResourcePath, dllTargetPath);
        }

        [Fact]
        public void TestSetupReadsConfigFile()
        {
            SetupDllTargetPathExists();
            string configFilePath = SetupConfigFileWithPlugin();

            _setupService.SetupPlugin();

            VerifyReadFile(configFilePath);
        }

        [Fact]
        public void TestSetupRewritesConfigFileWhenPluginNotLoaded()
        {
            SetupDllTargetPathExists();
            string configFilePath = SetupConfigFileNoPlugin();

            _setupService.SetupPlugin();

            VerifyReadFile(configFilePath);
            VerifyWriteConfigFileWithInstantTraining();
        }

        private string SetupConfigFileNoPlugin()
        {
            const string contents = @"
plugin load rconplugin";

            return SetupConfigFile(contents);
        }

        private string SetupConfigFileWithPlugin()
        {
            const string contents = @"
plugin load InstantTraining
plugin load rconplugin";

            return SetupConfigFile(contents);
        }

        private string SetupConfigFile(string contents)
        {
            string configFilePath = GetConfigFilePath();

            SetupReadFile(configFilePath, contents);

            return configFilePath;
        }

        private static string GetConfigFilePath()
        {
            return Path.Combine(GetBakkesModPath(), Constants.Steam.LoadPluginsFile);
        }

        private void SetupReadFile(string path, string contents)
        {
            _fileSystemProviderMock.Setup(fileSystemProvider => fileSystemProvider.ReadFile(path))
                                   .Returns(contents);
        }

        private void VerifyReadFile(string path)
        {
            _fileSystemProviderMock.Verify(fileSystemProvider => fileSystemProvider.ReadFile(path));
        }

        private void VerifyWriteConfigFileWithInstantTraining()
        {
            const string contents = @"
plugin load rconplugin
plugin load InstantTraining";

            VerifyWriteFile(GetConfigFilePath(), contents);
        }

        private void VerifyWriteFile(string path, string contents)
        {
            _fileSystemProviderMock.Verify(fileSystemProvider => fileSystemProvider.WriteFile(path, contents));
        }

        private string SetupDllResourcePath()
        {
            const string currentDirectory = "CurrentDirectory";
            SetupCurrentDirectory(currentDirectory);

            string dllResourcePath = Path.Combine(currentDirectory, Constants.ResourcesDirectory, Constants.DllName);
            return dllResourcePath;
        }

        private string SetupDllTargetPathExists()
        {
            string dllTargetPath = GetDllTargetPath();
            SetupFileExists(dllTargetPath);
            return dllTargetPath;
        }

        private static string SetupDllTargetPathMissing()
        {
            return GetDllTargetPath();
        }

        private static string GetDllTargetPath()
        {
            string dllTargetPath = Path.Combine(GetBakkesModPath(), Constants.Steam.PluginsDirectory, Constants.DllName);
            return dllTargetPath;
        }

        private static string GetBakkesModPath()
        {
            return Path.Combine(SteamGamesPath, Constants.Steam.RocketLeaguePath, Constants.Steam.BakkesModPath);
        }

        private void SetupCurrentDirectory(string path)
        {
            _fileSystemProviderMock.Setup(fileSystemProvider => fileSystemProvider.CurrentDirectory)
                                   .Returns(path);
        }

        private void SetupDirectoryExists(string path)
        {
            _fileSystemProviderMock.Setup(fileSystemProvider => fileSystemProvider.DirectoryExists(path))
                                   .Returns(true);
        }

        private void SetupFileExists(string path)
        {
            _fileSystemProviderMock.Setup(fileSystemProvider => fileSystemProvider.FileExists(path))
                                   .Returns(true);
        }

        private void VerifyQueryDirectoryExists(string path)
        {
            _fileSystemProviderMock.Verify(fileSystemProvider => fileSystemProvider.DirectoryExists(path));
        }

        private void VerifyQueryFileExists(string path)
        {
            _fileSystemProviderMock.Verify(fileSystemProvider => fileSystemProvider.FileExists(path));
        }

        private void VerifyCopyFile(string source, string target)
        {
            VerifyCopyFile(source, target, Times.Once);
        }

        private void VerifyCopyFile(string source, string target, Func<Times> times)
        {
            _fileSystemProviderMock.Verify(fileSystemProvider => fileSystemProvider.Copy(source, target), times);
        }
    }
}