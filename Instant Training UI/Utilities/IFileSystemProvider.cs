namespace Instant.Training.UI.Utilities
{
    public interface IFileSystemProvider
    {
        string CurrentDirectory { get; }

        bool DirectoryExists(string path);

        bool FileExists(string path);

        byte[] ReadFileBytes(string path);

        string ReadFile(string path);

        void WriteFile(string path, string contents);

        void AppendFile(string path, string contents);

        void Copy(string source, string target);
    }
}