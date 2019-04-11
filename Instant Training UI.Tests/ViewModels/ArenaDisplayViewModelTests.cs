namespace Instant.Training.UI.Tests.ViewModels
{
    using Instant.Training.UI.Services.Interfaces;
    using Instant.Training.UI.ViewModels;

    using Moq;

    using Xunit;

    public class ArenaDisplayViewModelTests
    {
        private readonly Mock<IRconService> _rconServiceMock;

        private readonly ArenaDisplayViewModel _arenaDisplayViewModel;

        public ArenaDisplayViewModelTests()
        {
            _rconServiceMock = new Mock<IRconService>();

            _arenaDisplayViewModel = new ArenaDisplayViewModel(_rconServiceMock.Object);
        }

        [Fact]
        public void TestDefaultArenaIsIndexZero()
        {
            Assert.Equal(Constants.ArenaDevNames[0], _arenaDisplayViewModel.ArenaName);
        }

        [Fact]
        public void TestArenaNamePropertyChanged()
        {
            const int expectedPropertyChangedInvocations = 1;
            int propertyChangedInvocations = 0;

            _arenaDisplayViewModel.PropertyChanged += (sender, e) => ++propertyChangedInvocations;

            _arenaDisplayViewModel.ArenaName = "SomeArenaName";

            Assert.Equal(expectedPropertyChangedInvocations, propertyChangedInvocations);
        }

        [Fact]
        public void TestNextArenaIncrementsIndex()
        {
            const int expectedArenaIndex = 5;

            CallNextArenaTimes(expectedArenaIndex);

            Assert.Equal(Constants.ArenaDevNames[expectedArenaIndex], _arenaDisplayViewModel.ArenaName);
        }

        [Fact]
        public void TestNextArenaWrapsIndex()
        {
            int arenaCount = Constants.ArenaDevNames.Length;
            int requiredArenaIndex = arenaCount + 10;

            CallNextArenaTimes(requiredArenaIndex);

            Assert.Equal(Constants.ArenaDevNames[requiredArenaIndex % arenaCount], _arenaDisplayViewModel.ArenaName);
        }

        [Fact]
        public void TestPreviousArenaDecrementsIndex()
        {
            const int expectedArenaIndex = 0;

            _arenaDisplayViewModel.SelectNextArena();
            _arenaDisplayViewModel.SelectPreviousArena();

            Assert.Equal(Constants.ArenaDevNames[expectedArenaIndex], _arenaDisplayViewModel.ArenaName);
        }

        [Fact]
        public void TestPreviousArenaWrapsIndex()
        {
            int expectedArenaIndex = Constants.ArenaDevNames.Length - 1;

            _arenaDisplayViewModel.SelectPreviousArena();

            Assert.Equal(Constants.ArenaDevNames[expectedArenaIndex], _arenaDisplayViewModel.ArenaName);
        }

        [Fact]
        public void TestTransmitsTrainingMapOnSetArenaName()
        {
            VerifyTransmitTrainingMap(Constants.ArenaDevNames[0]);
            _arenaDisplayViewModel.SelectNextArena();
            VerifyTransmitTrainingMap(Constants.ArenaDevNames[1]);
        }

        private void CallNextArenaTimes(int quantity)
        {
            for (int arenaIndex = 0; arenaIndex < quantity; ++arenaIndex)
            {
                _arenaDisplayViewModel.SelectNextArena();
            }
        }

        private void VerifyTransmitTrainingMap(string trainingMap)
        {
            _rconServiceMock.Verify(rconService => rconService.TransmitTrainingMap(trainingMap));
        }
    }
}