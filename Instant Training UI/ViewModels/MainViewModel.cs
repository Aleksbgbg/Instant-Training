namespace Instant.Training.UI.ViewModels
{
    using Instant.Training.UI.Services.Interfaces;
    using Instant.Training.UI.ViewModels.Interfaces;

    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private readonly IRconService _rconService;

        public MainViewModel(IArenaDisplayViewModel arenaDisplayViewModel, IRconService rconService)
        {
            ArenaDisplayViewModel = arenaDisplayViewModel;
            _rconService = rconService;
        }

        public IArenaDisplayViewModel ArenaDisplayViewModel { get; }

        private bool _enableInstantTraining = true;
        public bool EnableInstantTraining
        {
            get => _enableInstantTraining;

            set
            {
                if (_enableInstantTraining == value) return;

                _enableInstantTraining = value;
                NotifyOfPropertyChange(nameof(EnableInstantTraining));

                _rconService.ToggleModEnabled(_enableInstantTraining);
            }
        }
    }
}