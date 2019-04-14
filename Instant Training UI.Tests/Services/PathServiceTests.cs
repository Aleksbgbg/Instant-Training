namespace Instant.Training.UI.Tests.Services
{
    using System.IO;

    using Instant.Training.UI.Services;
    using Instant.Training.UI.Services.Interfaces;
    using Instant.Training.UI.Utilities;

    using Moq;

    using Xunit;

    public class PathServiceTests
    {
        private const string SteamPath = @"Z:\Steam";

        private static readonly string RocketLeaguePath = Path.Combine(SteamPath, Constants.Steam.RocketLeaguePath);

        private static readonly string BakkesModPath = Path.Combine(RocketLeaguePath, Constants.Steam.BakkesModPath);

        private static readonly string ModDllPath = Path.Combine(BakkesModPath, Constants.Steam.PluginsDirectory, Constants.DllName);

        private static readonly string PluginsConfigFilePath = Path.Combine(BakkesModPath, Constants.Steam.PluginsConfigFile);

        private readonly Mock<IFileSystemProvider> _fileSystemProviderMock;

        private readonly Mock<ISteamService> _steamServiceMock;

        private readonly PathService _pathService;

        public PathServiceTests()
        {
            _fileSystemProviderMock = new Mock<IFileSystemProvider>();

            _steamServiceMock = new Mock<ISteamService>();
            _steamServiceMock.Setup(steamService => steamService.GetSteamGamesPath())
                             .Returns(SteamPath);

            _pathService = new PathService(_fileSystemProviderMock.Object, _steamServiceMock.Object);
        }

        [Fact]
        public void TestLoadsSteamPathOnConstruct()
        {
            VerifyGetSteamPathCalled();
        }

        [Fact]
        public void TestRocketLeaguePath()
        {
            string rocketLeaguePath = _pathService.RocketLeaguePath;

            Assert.Equal(RocketLeaguePath, rocketLeaguePath);
        }

        [Fact]
        public void TestBakkesModPath()
        {
            string bakkesModPath = _pathService.BakkesModPath;

            Assert.Equal(BakkesModPath, bakkesModPath);
        }

        [Fact]
        public void TestModDllPath()
        {
            string modDllPath = _pathService.ModDllPath;

            Assert.Equal(ModDllPath, modDllPath);
        }

        [Fact]
        public void TestPluginsConfigFilePath()
        {
            string pluginsConfigFilePath = _pathService.PluginsConfigFilePath;

            Assert.Equal(PluginsConfigFilePath, pluginsConfigFilePath);
        }

        [Fact]
        public void TestDllResourcePath()
        {
            string currentDirectory = SetupCurrentDirectory();

            string dllResourcePath = _pathService.DllResourcePath;

            string expectedDllResourcePath = Path.Combine(currentDirectory, Constants.ResourcesDirectory, Constants.DllName);
            Assert.Equal(expectedDllResourcePath, dllResourcePath);
        }

        [Fact]
        public void TestBakkesModInjectorResourcePath()
        {
            string currentDirectory = SetupCurrentDirectory();

            string bakkesModInjectorResourcePath = _pathService.BakkesModInjectorResourcePath;

            string expectedBakkesModInjectorResourcePath = Path.Combine(currentDirectory, Constants.ResourcesDirectory, Constants.BakkesModInjectorFile);
            Assert.Equal(expectedBakkesModInjectorResourcePath, bakkesModInjectorResourcePath);
        }

        private string SetupCurrentDirectory()
        {
            const string currentDirectory = "Current";
            _fileSystemProviderMock.SetupGet(fileSystemProvider => fileSystemProvider.CurrentDirectory)
                                   .Returns(currentDirectory);
            return currentDirectory;
        }

        private void VerifyGetSteamPathCalled()
        {
            _steamServiceMock.Verify(steamService => steamService.GetSteamGamesPath());
        }
    }
}