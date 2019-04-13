namespace Instant.Training.UI.Tests.Services
{
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
            SetupFileSystemPathExists(rocketLeaguePath);

            bool rocketLeagueInstalled = _setupService.CheckRocketLeagueInstalled();

            VerifyFileSystemPathQueries(rocketLeaguePath);
            Assert.True(rocketLeagueInstalled);
        }

        [Fact]
        public void TestBakkesModInstalledChecksSteamPath()
        {
            string bakkesModPath = Path.Combine(SteamGamesPath, Constants.Steam.RocketLeaguePath, Constants.Steam.BakkesModPath);
            SetupFileSystemPathExists(bakkesModPath);

            bool bakkesModInstalled = _setupService.CheckBakkesModInstalled();

            VerifyFileSystemPathQueries(bakkesModPath);
            Assert.True(bakkesModInstalled);
        }

        private void SetupFileSystemPathExists(string path)
        {
            _fileSystemProviderMock.Setup(fileSystemProvider => fileSystemProvider.DirectoryExists(path))
                                   .Returns(true);
        }

        private void VerifyFileSystemPathQueries(string path)
        {
            _fileSystemProviderMock.Verify(fileSystemProvider => fileSystemProvider.DirectoryExists(path));
        }
    }
}