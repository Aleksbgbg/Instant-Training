namespace Instant.Training.UI.Utilities
{
    using System.IO;

    public class FileSystemProvider : IFileSystemProvider
    {
        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}