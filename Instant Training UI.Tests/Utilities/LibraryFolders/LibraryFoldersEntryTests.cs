namespace Instant.Training.UI.Tests.Utilities.LibraryFolders
{
    using Instant.Training.UI.Utilities.LibraryFolders;

    using Xunit;

    public class LibraryFoldersEntryTests
    {
        [Fact]
        public void TestInvalidWhenWithOneComponent()
        {
            const string entry = "\"abcdef\"";

            LibraryFoldersEntry libraryFoldersEntry = new LibraryFoldersEntry(entry);

            Assert.False(libraryFoldersEntry.IsValid());
        }

        [Fact]
        public void TestInvalidWhenComponentsWithoutQuotes()
        {
            const string entry = "abc def";

            LibraryFoldersEntry libraryFoldersEntry = new LibraryFoldersEntry(entry);

            Assert.False(libraryFoldersEntry.IsValid());
        }

        [Fact]
        public void TestValidWithQuotesAroundComponents()
        {
            const string entry = "\"abc\" \"def\"";

            LibraryFoldersEntry libraryFoldersEntry = new LibraryFoldersEntry(entry);

            Assert.True(libraryFoldersEntry.IsValid());
        }

        [Fact]
        public void TestValidWithWhiteSpace()
        {
            const string entry = "\t\t    \"abc\" \t\t\t\t\"def\"  ";

            LibraryFoldersEntry libraryFoldersEntry = new LibraryFoldersEntry(entry);

            Assert.True(libraryFoldersEntry.IsValid());
        }

        [Fact]
        public void TestKeyValueNotSetWhenInvalid()
        {
            const string entry = "abc def";

            LibraryFoldersEntry libraryFoldersEntry = new LibraryFoldersEntry(entry);

            Assert.False(libraryFoldersEntry.IsValid());
            Assert.Null(libraryFoldersEntry.Key);
            Assert.Null(libraryFoldersEntry.Value);
        }

        [Fact]
        public void TestParseKeyValue()
        {
            const string entry = "	\t\"ContentStatsID\"\t\t\"-7061122333939149038\"";

            LibraryFoldersEntry libraryFoldersEntry = new LibraryFoldersEntry(entry);

            Assert.Equal("ContentStatsID", libraryFoldersEntry.Key);
            Assert.Equal("-7061122333939149038", libraryFoldersEntry.Value);
        }

        [Fact]
        public void TestParsesPath()
        {
            const string entry = "\t\"1\"\t\t\"Z:\\\\Steam\"";

            LibraryFoldersEntry libraryFoldersEntry = new LibraryFoldersEntry(entry);

            Assert.Equal("1", libraryFoldersEntry.Key);
            Assert.Equal(@"Z:\Steam", libraryFoldersEntry.Value);
        }
    }
}