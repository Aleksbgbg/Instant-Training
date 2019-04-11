namespace Instant.Training.UI.Tests.ViewModels
{
    using Instant.Training.UI.ViewModels;
    using Instant.Training.UI.ViewModels.Interfaces;

    using Moq;

    using Xunit;

    public class MainViewModelTests
    {
        private readonly Mock<IArenaDisplayViewModel> _arenaDisplayViewModelMock;

        private readonly MainViewModel _mainViewModel;

        public MainViewModelTests()
        {
            _arenaDisplayViewModelMock = new Mock<IArenaDisplayViewModel>();

            _mainViewModel = new MainViewModel(_arenaDisplayViewModelMock.Object);
        }

        [Fact]
        public void TestArenaDisplayViewModelAssigned()
        {
            Assert.Equal(_arenaDisplayViewModelMock.Object, _mainViewModel.ArenaDisplayViewModel);
        }
    }
}