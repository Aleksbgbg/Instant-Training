namespace Instant.Training.UI.Tests.Services
{
    using System;
    using System.IO;

    using Instant.Training.UI.Services;
    using Instant.Training.UI.Utilities;
    using Instant.Training.UI.Utilities.LibraryFolders;

    using Moq;

    using Xunit;

    public class SteamServiceTests
    {
        private readonly Mock<IRegistryProvider> _registryProviderMock;

        private readonly Mock<IFileSystemProvider> _fileSystemProviderMock;

        private readonly Mock<ILibraryFoldersParser> _libraryFoldersParserMock;

        private readonly SteamService _steamService;

        private string _win32KeyContents;

        private string _win64KeyContents;

        public SteamServiceTests()
        {
            _registryProviderMock = new Mock<IRegistryProvider>();

            _registryProviderMock.Setup(registryProvider => registryProvider.GetValueFromKey<string>(Constants.Steam.Win32RegistryKey, Constants.Steam.InstallPathValue))
                                 .Returns(() => _win32KeyContents);

            _registryProviderMock.Setup(registryProvider => registryProvider.GetValueFromKey<string>(Constants.Steam.Win64RegistryKey, Constants.Steam.InstallPathValue))
                                 .Returns(() => _win64KeyContents);

            _fileSystemProviderMock = new Mock<IFileSystemProvider>();

            _libraryFoldersParserMock = new Mock<ILibraryFoldersParser>();

            _steamService = new SteamService(_registryProviderMock.Object, _fileSystemProviderMock.Object, _libraryFoldersParserMock.Object);
        }

        [Fact]
        public void TestSeeksWin32RegistryKey()
        {
            _win32KeyContents = "SomeValidSteamPath";

            _steamService.GetSteamGamesPath();

            VerifyGetWin32Key(Times.Once);
            VerifyGetWin64Key(Times.Never);
        }

        [Fact]
        public void TestSeeksWin64RegistryKeyAsFallback()
        {
            _win32KeyContents = null;
            _win64KeyContents = "SomeValidSteamPath";

            _steamService.GetSteamGamesPath();

            VerifyGetWin32Key(Times.Once);
            VerifyGetWin64Key(Times.Once);
        }

        [Fact]
        public void TestThrowsWhenSteamPathNotInRegistry()
        {
            _win32KeyContents = null;
            _win64KeyContents = null;

            Action registryCheck = () => _steamService.GetSteamGamesPath();

            Assert.Throws<InvalidOperationException>(registryCheck);
        }

        [Fact]
        public void TestSeeksLibraryFolders()
        {
            _win32KeyContents = null;
            _win64KeyContents = "SomeValidSteamPath";

            string libraryFoldersPath = Path.Combine(_win64KeyContents, Constants.Steam.LibraryFoldersPath);

            _steamService.GetSteamGamesPath();

            VerifySeeksFile(libraryFoldersPath);
        }

        [Fact]
        public void TestParsesLibraryFoldersFile()
        {
            const string steamGamesFolder = "Z:\\Steam";

            string libraryFoldersContent = $@"""LibraryFolders""
{{
	""TimeNextStatsReport""		""1555173196""
	""ContentStatsID""		""-7061122333939149038""
	""1""		""{steamGamesFolder}""
}}";

            _win32KeyContents = null;
            _win64KeyContents = "SomeValidSteamPath";

            string libraryFoldersPath = Path.Combine(_win64KeyContents, Constants.Steam.LibraryFoldersPath);
            _fileSystemProviderMock.Setup(fileProvider => fileProvider.ReadFile(libraryFoldersPath))
                                   .Returns(libraryFoldersContent);

            _steamService.GetSteamGamesPath();

            _libraryFoldersParserMock.Verify(libraryFoldersParser => libraryFoldersParser.ParseSteamGamesPath(libraryFoldersContent));
        }

        private void VerifyGetWin32Key(Func<Times> times)
        {
            VerifyGetKey(Constants.Steam.Win32RegistryKey, times);
        }

        private void VerifyGetWin64Key(Func<Times> times)
        {
            VerifyGetKey(Constants.Steam.Win64RegistryKey, times);
        }

        private void VerifyGetKey(string key, Func<Times> times)
        {
            _registryProviderMock.Verify(registryProvider => registryProvider.GetValueFromKey<string>(key, Constants.Steam.InstallPathValue), times);
        }

        private void VerifySeeksFile(string file)
        {
            _fileSystemProviderMock.Verify(fileProvider => fileProvider.ReadFile(file));
        }
    }
}