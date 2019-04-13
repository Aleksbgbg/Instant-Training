namespace Instant.Training.UI.Tests.Utilities.LibraryFolders
{
    using Instant.Training.UI.Utilities.LibraryFolders;

    using Xunit;

    public class LibraryFoldersFileTests
    {
        [Fact]
        public void TestParsesEmptyFile()
        {
            const string fileContents = @"""LibraryFolders""
{
}";

            LibraryFoldersFile libraryFoldersFile = new LibraryFoldersFile(fileContents);

            Assert.Empty(libraryFoldersFile.Entries);
        }

        [Fact]
        public void TestParsesEntries()
        {
            const string fileContents = @"""LibraryFolders""
{
	""TimeNextStatsReport""		""1555173196""
	""ContentStatsID""		""-7061122333939149038""
	""1""		""Z:\\Steam""
}";

            LibraryFoldersFile libraryFoldersFile = new LibraryFoldersFile(fileContents);

            Assert.Equal(3, libraryFoldersFile.Entries.Length);
            Assert.Equal(@"Z:\Steam", libraryFoldersFile.Entries[2].Value);
        }

        [Fact]
        public void TestAllEntriesValid()
        {
            const string fileContents = @"""LibraryFolders""
{
	""TimeNextStatsReport""		""1555173196""
	""ContentStatsID""		""-7061122333939149038""
	""1""		""Z:\\Steam""
}";

            LibraryFoldersFile libraryFoldersFile = new LibraryFoldersFile(fileContents);

            Assert.All(libraryFoldersFile.Entries, entry => entry.IsValid());
        }
    }
}