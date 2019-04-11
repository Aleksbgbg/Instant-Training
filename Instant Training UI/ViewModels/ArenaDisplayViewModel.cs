namespace Instant.Training.UI.ViewModels
{
    using Instant.Training.UI.ViewModels.Interfaces;

    public class ArenaDisplayViewModel : ViewModelBase, IArenaDisplayViewModel
    {
        private static readonly int ArenaNamesLength = Constants.ArenaNames.Length;

        private int _arenaIndex;

        public ArenaDisplayViewModel()
        {
            _arenaIndex = 0;

            PickArenaNameFromIndex();
        }

        private string _arenaName;
        public string ArenaName
        {
            get => _arenaName;

            set
            {
                if (_arenaName == value) return;

                _arenaName = value;
                NotifyOfPropertyChange(nameof(ArenaName));
            }
        }

        public void SelectNextArena()
        {
            _arenaIndex = ((_arenaIndex + 1) % ArenaNamesLength);

            PickArenaNameFromIndex();
        }

        public void SelectPreviousArena()
        {
            _arenaIndex = (((_arenaIndex - 1) + ArenaNamesLength) % ArenaNamesLength);

            PickArenaNameFromIndex();
        }

        private void PickArenaNameFromIndex()
        {
            ArenaName = Constants.ArenaNames[_arenaIndex];
        }
    }
}