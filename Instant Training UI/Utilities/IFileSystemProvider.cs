namespace Instant.Training.UI.Utilities
{
    public interface IFileSystemProvider
    {
        bool DirectoryExists(string path);

        bool FileExists(string path);

        string ReadFile(string path);
    }
}