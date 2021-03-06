﻿namespace Instant.Training.UI.Utilities
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

        public byte[] ReadFileBytes(string path)
        {
            return File.ReadAllBytes(path);
        }

        public string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }

        public void WriteFile(string path, string contents)
        {
            File.WriteAllText(path, contents);
        }

        public void AppendFile(string path, string contents)
        {
            File.AppendAllText(path, contents);
        }

        public void Copy(string source, string target)
        {
            File.Copy(source, target);
        }
    }
}