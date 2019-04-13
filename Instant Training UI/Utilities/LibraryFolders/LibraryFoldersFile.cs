namespace Instant.Training.UI.Utilities.LibraryFolders
{
    using System.Linq;

    public class LibraryFoldersFile
    {
        public LibraryFoldersFile(string fileContents)
        {
            Entries = fileContents.Split('\n')
                                  .Select(line => line.TrimEnd('\r'))
                                  .Where(line => line != string.Empty)
                                  .Select(line => new LibraryFoldersEntry(line))
                                  .Where(entry => entry.IsValid())
                                  .ToArray();
        }

        public LibraryFoldersEntry[] Entries { get; }
    }
}