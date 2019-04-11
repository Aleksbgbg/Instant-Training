namespace Instant.Training.UI.Tests.Services
{
    using Instant.Training.UI.Services;
    using Instant.Training.UI.Utilities;

    using Moq;

    using Xunit;

    public class RconServiceTests
    {
        private Mock<IWebSocket> _webSocketMock;

        private readonly RconService _rconService;

        public RconServiceTests()
        {
            _webSocketMock = new Mock<IWebSocket>();

            _rconService = new RconService(_webSocketMock.Object);
        }

        [Fact]
        public void TestConnects()
        {
            _rconService.Connect();

            VerifyConnectWebSocket();
        }

        [Fact]
        public void TestAuthenticates()
        {
            _rconService.Connect();

            VerifyAuthenticateRcon();
        }

        [Fact]
        public void TestSetsTrainingMapCvar()
        {
            string trainingMap = Constants.ArenaDevNames[0];

            _rconService.TransmitTrainingMap(trainingMap);

            VerifyWebSocketMessageSent($"{Constants.Mod.TrainingMapCvar} {trainingMap}{Constants.Mod.MapSuffix}");
        }

        private void VerifyConnectWebSocket()
        {
            _webSocketMock.Verify(webSocket => webSocket.Connect(), Times.Once);
        }

        private void VerifyAuthenticateRcon()
        {
            VerifyWebSocketMessageSent($"rcon_password {Constants.RCON.Password}");
        }

        private void VerifyWebSocketMessageSent(string message)
        {
            _webSocketMock.Verify(webSocket => webSocket.Send(message));
        }
    }
}