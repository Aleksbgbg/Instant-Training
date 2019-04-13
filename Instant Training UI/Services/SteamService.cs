namespace Instant.Training.UI.Services
{
    using System;
    using System.IO;

    using Instant.Training.UI.Services.Interfaces;
    using Instant.Training.UI.Utilities;
    using Instant.Training.UI.Utilities.LibraryFolders;

    public class SteamService : ISteamService
    {
        private readonly IRegistryProvider _registryProvider;

        private readonly IFileSystemProvider _fileSystemProvider;

        private readonly ILibraryFoldersParser _libraryFoldersParser;

        public SteamService(IRegistryProvider registryProvider, IFileSystemProvider fileSystemProvider, ILibraryFoldersParser libraryFoldersParser)
        {
            _registryProvider = registryProvider;
            _fileSystemProvider = fileSystemProvider;
            _libraryFoldersParser = libraryFoldersParser;
        }

        public string GetSteamGamesPath()
        {
            string libraryFoldersPath = FindLibraryFoldersPath();
            string libraryFoldersContent = _fileSystemProvider.ReadFile(libraryFoldersPath);

            string steamGamesPath = _libraryFoldersParser.ParseSteamGamesPath(libraryFoldersContent);

            return steamGamesPath;
        }

        private string FindLibraryFoldersPath()
        {
            string steamInstallPath = FindSteamInstallPath();

            string libraryFoldersPath = Path.Combine(steamInstallPath, Constants.Steam.LibraryFoldersPath);

            return libraryFoldersPath;
        }

        private string FindSteamInstallPath()
        {
            string win32SteamPath = FindWin32SteamPath();

            if (win32SteamPath == null)
            {
                string win64SteamPath = FindWin64SteamPath();

                if (win64SteamPath == null)
                {
                    throw new InvalidOperationException("Steam not installed.");
                }

                return win64SteamPath;
            }

            return win32SteamPath;
        }

        private string FindWin64SteamPath()
        {
            return FindSteamPathFromRegistry(Constants.Steam.Win64RegistryKey);
        }

        private string FindWin32SteamPath()
        {
            return FindSteamPathFromRegistry(Constants.Steam.Win32RegistryKey);
        }

        private string FindSteamPathFromRegistry(string registryKey)
        {
            return _registryProvider.GetValueFromKey<string>(registryKey, Constants.Steam.InstallPathValue);
        }
    }
}