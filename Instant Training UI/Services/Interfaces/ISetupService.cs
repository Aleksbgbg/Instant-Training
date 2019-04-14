namespace Instant.Training.UI.Services.Interfaces
{
    public interface ISetupService
    {
        bool CheckRocketLeagueInstalled();

        bool CheckBakkesModInstalled();

        bool CheckModDllInstalled();

        void InstallModDll();

        bool CheckPluginLoadsOnStartup();

        void LoadPluginOnStartup();
    }
}