namespace Instant.Training.UI.Tests.Services
{
    using System;
    using System.Linq.Expressions;
    using System.Text;

    using Instant.Training.UI.Services;
    using Instant.Training.UI.Services.Interfaces;
    using Instant.Training.UI.Utilities;

    using Moq;

    using Xunit;

    public class SetupServiceTests
    {
        private readonly Mock<IPathService> _pathServiceMock;

        private readonly Mock<IFileSystemProvider> _fileSystemProviderMock;

        private readonly Mock<IHashProvider> _hashProviderMock;

        private readonly SetupService _setupService;

        public SetupServiceTests()
        {
            _pathServiceMock = new Mock<IPathService>();

            _fileSystemProviderMock = new Mock<IFileSystemProvider>();

            _hashProviderMock = new Mock<IHashProvider>();

            _setupService = new SetupService(_pathServiceMock.Object, _fileSystemProviderMock.Object, _hashProviderMock.Object);
        }

        [Fact]
        public void TestCheckRocketLeagueInstalled()
        {
            const string rocketLeaguePath = "RocketLeague";
            SetupDirectory(directoryService => directoryService.RocketLeaguePath, rocketLeaguePath);

            bool rocketLeagueInstalled = _setupService.CheckRocketLeagueInstalled();

            VerifyQueryDirectoryExists(rocketLeaguePath);
            Assert.True(rocketLeagueInstalled);
        }

        [Fact]
        public void TestCheckBakkesModInstalled()
        {
            const string bakkesModPath = "BakkesMod";
            SetupDirectory(directoryService => directoryService.BakkesModPath, bakkesModPath);

            bool bakkesModInstalled = _setupService.CheckBakkesModInstalled();

            VerifyQueryDirectoryExists(bakkesModPath);
            Assert.True(bakkesModInstalled);
        }

        [Fact]
        public void TestCheckDllInstalledChecksFileExists()
        {
            const string dllPath = "DllPath";
            SetupFile(directoryService => directoryService.ModDllPath, dllPath);

            bool dllInstalled = _setupService.CheckModDllInstalled();

            VerifyQueryFileExists(dllPath);
        }

        [Fact]
        public void TestCheckDllInstalledComparesHashes()
        {
            const string dllPath = "DllPath";
            const string contents = "SomeDllContents";
            SetupFile(directoryService => directoryService.ModDllPath, dllPath, contents);

            const string resourceDllPath = "ResourceDllPath";
            const string resourceContents = "SomeDllContents";
            SetupFile(directoryService => directoryService.DllResourcePath, resourceDllPath, resourceContents);

            bool modInstalled = _setupService.CheckModDllInstalled();

            VerifyReadFileBytes(dllPath);
            VerifyCheckHash(Encoding.ASCII.GetBytes(contents));
            VerifyReadFileBytes(resourceDllPath);
            VerifyCheckHash(Encoding.ASCII.GetBytes(resourceContents));
            Assert.True(modInstalled);
        }

        [Fact]
        public void TestInstallModDll()
        {
            const string pluginSourcePath = "PluginResource";
            const string pluginTargetPath = "PluginTarget";

            SetupFile(directoryService => directoryService.DllResourcePath, pluginSourcePath);
            SetupFile(directoryService => directoryService.ModDllPath, pluginTargetPath);

            _setupService.InstallModDll();

            VerifyCopyFile(pluginSourcePath, pluginTargetPath);
        }

        [Fact]
        public void TestCheckPluginLoadsOnStartupReadsFile()
        {
            const string pluginConfigFile = "PluginConfig";
            SetupFile(directoryService => directoryService.PluginsConfigFilePath, pluginConfigFile, contents: string.Empty);

            _setupService.CheckPluginLoadsOnStartup();

            VerifyReadFile(pluginConfigFile);
        }

        [Fact]
        public void TestCheckPluginLoadsOnStartupRecognisesValidFile()
        {
            const string pluginConfigFile = "PluginConfig";
            string fileContents = $"plugin load rconplugin\r\nplugin load {Constants.PluginName}";

            SetupFile(directoryService => directoryService.PluginsConfigFilePath, pluginConfigFile, fileContents);

            bool pluginLoadsOnStartup = _setupService.CheckPluginLoadsOnStartup();

            Assert.True(pluginLoadsOnStartup);
        }

        [Fact]
        public void TestCheckPluginLoadsOnStartupRecognisesInvalidFile()
        {
            const string pluginConfigFile = "PluginConfig";
            const string fileContents = "plugin load rconplugin";

            SetupFile(directoryService => directoryService.PluginsConfigFilePath, pluginConfigFile, fileContents);

            bool pluginLoadsOnStartup = _setupService.CheckPluginLoadsOnStartup();

            Assert.False(pluginLoadsOnStartup);
        }

        [Fact]
        public void TestLoadPluginOnStartupWritesFile()
        {
            const string pluginConfigFile = "PluginConfig";
            const string fileContents = "plugin load rconplugin";

            SetupFile(directoryService => directoryService.PluginsConfigFilePath, pluginConfigFile, fileContents);

            _setupService.LoadPluginOnStartup();

            VerifyAppendFile(pluginConfigFile, $"plugin load {Constants.PluginName}");
        }

        private void SetupDirectory(Expression<Func<IPathService, string>> directoryServicePath, string directory)
        {
            _pathServiceMock.SetupGet(directoryServicePath).Returns(directory);

            _fileSystemProviderMock.Setup(fileSystemProvider => fileSystemProvider.DirectoryExists(directory)).Returns(true);
        }

        private void SetupFile(Expression<Func<IPathService, string>> directoryServicePath, string file, string contents)
        {
            SetupFile(directoryServicePath, file);
            _fileSystemProviderMock.Setup(fileSystemProvider => fileSystemProvider.ReadFile(file))
                                   .Returns(contents);
            _fileSystemProviderMock.Setup(fileSystemProvider => fileSystemProvider.ReadFileBytes(file))
                                   .Returns(Encoding.ASCII.GetBytes(contents));
        }

        private void SetupFile(Expression<Func<IPathService, string>> directoryServicePath, string file)
        {
            _pathServiceMock.SetupGet(directoryServicePath)
                            .Returns(file);

            _fileSystemProviderMock.Setup(fileSystemProvider => fileSystemProvider.FileExists(file))
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

        private void VerifyReadFile(string path)
        {
            _fileSystemProviderMock.Verify(fileSystemProvider => fileSystemProvider.ReadFile(path));
        }

        private void VerifyReadFileBytes(string path)
        {
            _fileSystemProviderMock.Verify(fileSystemProvider => fileSystemProvider.ReadFileBytes(path));
        }

        private void VerifyAppendFile(string path, string contents)
        {
            _fileSystemProviderMock.Verify(fileSystemProvider => fileSystemProvider.AppendFile(path, contents));
        }

        private void VerifyCopyFile(string source, string target)
        {
            _fileSystemProviderMock.Verify(fileSystemProvider => fileSystemProvider.Copy(source, target));
        }

        private void VerifyCheckHash(byte[] contents)
        {
            _hashProviderMock.Verify(hashProvider => hashProvider.Hash(contents));
        }
    }
}