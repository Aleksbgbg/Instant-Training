namespace Instant.Training.UI.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface ISetupService
    {
        bool CheckRocketLeagueInstalled();

        bool CheckBakkesModInstalled();

        Task InstallBakkesMod();

        bool CheckModDllInstalled();

        void InstallModDll();

        bool CheckPluginLoadsOnStartup();

        void LoadPluginOnStartup();
    }
}