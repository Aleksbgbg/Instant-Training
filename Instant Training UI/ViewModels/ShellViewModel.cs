namespace Instant.Training.UI.ViewModels
{
    using Instant.Training.UI.ViewModels.Interfaces;

    public sealed class ShellViewModel : ViewModelBase, IShellViewModel
    {
        public ShellViewModel(IMainViewModel mainViewModel)
        {
            DisplayName = Constants.AppName;

            MainViewModel = mainViewModel;
        }

        public IMainViewModel MainViewModel { get; }
    }
}