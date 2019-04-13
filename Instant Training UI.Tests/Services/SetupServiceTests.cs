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
        private readonly Mock<ISteamService> _steamServiceMock;

        private readonly Mock<IFileSystemProvider> _fileSystemProviderMock;

        private readonly SetupService _setupService;

        public SetupServiceTests()
        {
            _steamServiceMock = new Mock<ISteamService>();

            _fileSystemProviderMock = new Mock<IFileSystemProvider>();

            _setupService = new SetupService(_steamServiceMock.Object, _fileSystemProviderMock.Object);
        }

        [Fact]
        public void TestRocketLeagueInstalledChecksSteamPath()
        {
            const string steamGamesPath = "Z:\\Steam";
            string rocketLeaguePath = Path.Combine(steamGamesPath, Constants.Steam.RocketLeaguePath);

            _steamServiceMock.Setup(steamService => steamService.GetSteamGamesPath())
                             .Returns(steamGamesPath);

            _fileSystemProviderMock.Setup(fileSystemProvider => fileSystemProvider.DirectoryExists(rocketLeaguePath))
                                   .Returns(true);

            bool rocketLeagueInstalled = _setupService.CheckRocketLeagueInstalled();

            _fileSystemProviderMock.Verify(fileSystemProvider => fileSystemProvider.DirectoryExists(rocketLeaguePath));
            Assert.True(rocketLeagueInstalled);
        }
    }
}