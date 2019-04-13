namespace Instant.Training.UI.Services
{
    using System.IO;

    using Instant.Training.UI.Services.Interfaces;
    using Instant.Training.UI.Utilities;

    public class SetupService : ISetupService
    {
        private readonly ISteamService _steamService;

        private readonly IFileSystemProvider _fileSystemProvider;

        public SetupService(ISteamService steamService, IFileSystemProvider fileSystemProvider)
        {
            _steamService = steamService;
            _fileSystemProvider = fileSystemProvider;
        }

        public bool CheckRocketLeagueInstalled()
        {
            string steamGamesPath = _steamService.GetSteamGamesPath();

            string rocketLeaguePath = Path.Combine(steamGamesPath, Constants.Steam.RocketLeaguePath);

            return _fileSystemProvider.DirectoryExists(rocketLeaguePath);
        }
    }
}