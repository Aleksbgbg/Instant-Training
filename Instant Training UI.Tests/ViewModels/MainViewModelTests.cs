namespace Instant.Training.UI.Tests.ViewModels
{
    using Instant.Training.UI.Services.Interfaces;
    using Instant.Training.UI.ViewModels;
    using Instant.Training.UI.ViewModels.Interfaces;

    using Moq;

    using Xunit;

    public class MainViewModelTests
    {
        private readonly Mock<IRconService> _rconServiceMock;

        private readonly Mock<IArenaDisplayViewModel> _arenaDisplayViewModelMock;

        private readonly MainViewModel _mainViewModel;

        public MainViewModelTests()
        {
            _rconServiceMock = new Mock<IRconService>();

            _arenaDisplayViewModelMock = new Mock<IArenaDisplayViewModel>();

            _mainViewModel = new MainViewModel(_arenaDisplayViewModelMock.Object, _rconServiceMock.Object);
        }

        [Fact]
        public void TestArenaDisplayViewModelAssigned()
        {
            Assert.Equal(_arenaDisplayViewModelMock.Object, _mainViewModel.ArenaDisplayViewModel);
        }

        [Fact]
        public void TestInstantTrainingEnabledByDefault()
        {
            Assert.True(_mainViewModel.EnableInstantTraining);
        }

        [Fact]
        public void TestInstantTrainingToggleCallsRconService()
        {
            const bool modEnabled = false;

            _mainViewModel.EnableInstantTraining = modEnabled;

            _rconServiceMock.Verify(rconService => rconService.ToggleModEnabled(modEnabled));
        }
    }
}