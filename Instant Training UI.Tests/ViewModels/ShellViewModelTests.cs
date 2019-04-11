namespace Instant.Training.UI.Tests.ViewModels
{
    using Instant.Training.UI.ViewModels;
    using Instant.Training.UI.ViewModels.Interfaces;

    using Moq;

    using Xunit;

    public class ShellViewModelTests
    {
        private readonly ShellViewModel _shellViewModel;

        private readonly Mock<IMainViewModel> _mainViewModelMock;

        public ShellViewModelTests()
        {
            _mainViewModelMock = new Mock<IMainViewModel>();

            _shellViewModel = new ShellViewModel(_mainViewModelMock.Object);
        }

        [Fact]
        public void TestDisplayNameEqualsAppName()
        {
            Assert.Equal(Constants.AppName, _shellViewModel.DisplayName);
        }

        [Fact]
        public void TestMainViewModelAssigned()
        {
            Assert.Equal(_mainViewModelMock.Object, _shellViewModel.MainViewModel);
        }
    }
}