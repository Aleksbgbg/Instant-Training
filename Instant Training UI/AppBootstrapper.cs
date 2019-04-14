namespace Instant.Training.UI
{
    using System;
    using System.Windows;

    using Caliburn.Micro.Wrapper;

    using Instant.Training.UI.Services;
    using Instant.Training.UI.Services.Interfaces;
    using Instant.Training.UI.Utilities;
    using Instant.Training.UI.Utilities.LibraryFolders;
    using Instant.Training.UI.ViewModels;
    using Instant.Training.UI.ViewModels.Interfaces;

    internal class AppBootstrapper : BootstrapperBase<IShellViewModel>
    {
        protected override void RegisterViewModels(IViewModelFactory viewModelFactory)
        {
            Container.Singleton<IShellViewModel, ShellViewModel>();
            Container.Singleton<IMainViewModel, MainViewModel>();
            Container.Singleton<IArenaDisplayViewModel, ArenaDisplayViewModel>();
        }

        protected override void RegisterServices()
        {
            Container.Singleton<IAppDataService, AppDataService>();
            Container.Singleton<IDataService, DataService>();

            Container.Singleton<ILibraryFoldersParser, LibraryFoldersParser>();
            Container.Singleton<IFileSystemProvider, FileSystemProvider>();
            Container.Singleton<IRegistryProvider, RegistryProvider>();
            Container.Singleton<ISteamService, SteamService>();

            Container.Singleton<IPathService, PathService>();
            Container.Singleton<IHashProvider, HashProvider>();
            Container.Singleton<ISetupService, SetupService>();

            Container.RegisterHandler(typeof(IWebSocket), null, container => new WebSocketAdapter($"ws://{Constants.RCON.Host}:{Constants.RCON.Port}/"));
            Container.Singleton<IRconService, RconService>();
        }

        protected override void OnStartupBeforeDisplayRootView(object sender, StartupEventArgs e)
        {
            Container.GetInstance<IRconService>().Connect();
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            Container.GetInstance<IArenaDisplayViewModel>().SaveArena();
        }
    }
}