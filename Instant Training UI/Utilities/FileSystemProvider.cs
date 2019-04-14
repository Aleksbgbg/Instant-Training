namespace Instant.Training.UI.Utilities
{
    using System;
    using System.IO;

    public class FileSystemProvider : IFileSystemProvider
    {
        public string CurrentDirectory => AppDomain.CurrentDomain.BaseDirectory;

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

        public void WriteFile(string path, string contents)
        {
            File.WriteAllText(path, contents);
        }

        public void Copy(string source, string target)
        {
            File.Copy(source, target);
        }
    }
}