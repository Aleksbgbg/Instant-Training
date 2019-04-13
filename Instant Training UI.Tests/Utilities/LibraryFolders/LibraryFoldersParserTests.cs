namespace Instant.Training.UI.Tests.Utilities.LibraryFolders
{
    using System;

    using Instant.Training.UI.Utilities.LibraryFolders;

    using Xunit;

    public class LibraryFoldersParserTests
    {
        private readonly LibraryFoldersParser _libraryFoldersParser;

        public LibraryFoldersParserTests()
        {
            _libraryFoldersParser = new LibraryFoldersParser();
        }

        [Fact]
        public void TestParseSteamPath()
        {
            const string steamGamesFolder = "Z:\\Steam";

            string libraryFoldersContent = $@"""LibraryFolders""
{{
	""TimeNextStatsReport""		""1555173196""
	""ContentStatsID""		""-7061122333939149038""
	""1""		""{steamGamesFolder}""
}}";

            string steamGamesPath = _libraryFoldersParser.ParseSteamGamesPath(libraryFoldersContent);

            Assert.Equal(steamGamesFolder, steamGamesPath);
        }

        [Fact]
        public void TestThrowsWhenSteamPathNotPresent()
        {
            const string libraryFoldersContent = @"""LibraryFolders""
{{
	""TimeNextStatsReport""		""1555173196""
	""ContentStatsID""		""-7061122333939149038""
}}";

            Action parseSteamGamesPath = () => _libraryFoldersParser.ParseSteamGamesPath(libraryFoldersContent);

            Assert.Throws<InvalidOperationException>(parseSteamGamesPath);
        }
    }
}