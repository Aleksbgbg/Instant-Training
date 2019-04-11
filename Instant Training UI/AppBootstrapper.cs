namespace Instant.Training.UI
{
    using Caliburn.Micro.Wrapper;

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
    }
}