namespace Instant.Training.UI.Utilities.LibraryFolders
{
    using System;

    public class LibraryFoldersParser : ILibraryFoldersParser
    {
        private const string SteamGamesPathKey = "1";

        public string ParseSteamGamesPath(string libraryFoldersContent)
        {
            LibraryFoldersFile libraryFoldersFile = new LibraryFoldersFile(libraryFoldersContent);

            foreach (LibraryFoldersEntry entry in libraryFoldersFile.Entries)
            {
                if (entry.Key == SteamGamesPathKey)
                {
                    return entry.Value;
                }
            }

            throw new InvalidOperationException("libraryfolders does not contain Steam games path.");
        }
    }
}