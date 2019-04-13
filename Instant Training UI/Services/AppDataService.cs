namespace Instant.Training.UI.Services
{
    using System;
    using System.IO;

    using Instant.Training.UI.Services.Interfaces;

    public class AppDataService : IAppDataService
    {
        private static readonly string ApplicationPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Constants.AppName);

        public AppDataService()
        {
            Directory.CreateDirectory(ApplicationPath);
        }

        public string GetFolder(string name)
        {
            string directoryPath = Path.Combine(ApplicationPath, name);

            Directory.CreateDirectory(directoryPath);

            return directoryPath;
        }

        public string GetFile(string name, string defaultContents = "")
        {
            return GetFile(name, () => defaultContents);
        }

        public string GetFile(string name, Func<string> defaultContents)
        {
            string filePath = Path.Combine(ApplicationPath, name);

            if (!File.Exists(filePath))
            {
                string directory = Path.GetDirectoryName(filePath);

                Directory.CreateDirectory(directory);
                File.WriteAllText(filePath, defaultContents());
            }

            return filePath;
        }
    }
}