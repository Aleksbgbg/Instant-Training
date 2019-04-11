namespace Instant.Training.UI.ViewModels
{
    using Instant.Training.UI.ViewModels.Interfaces;

    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        public MainViewModel(IArenaDisplayViewModel arenaDisplayViewModel)
        {
            ArenaDisplayViewModel = arenaDisplayViewModel;
        }

        public IArenaDisplayViewModel ArenaDisplayViewModel { get; }
    }
}