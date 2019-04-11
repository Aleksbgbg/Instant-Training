namespace Instant.Training.UI.Services
{
    using Instant.Training.UI.Services.Interfaces;
    using Instant.Training.UI.Utilities;

    using WebSocketSharp;

    public class RconService : IRconService
    {
        private readonly IWebSocket _websocket;

        private bool _authenticated;

        public RconService(IWebSocket websocket)
        {
            _websocket = websocket;
        }

        public void Connect()
        {
            _websocket.Connect();
            _websocket.OnMessage += OnMessage;
            Authenticate();
        }

        public void TransmitTrainingMap(string trainingMap)
        {
            _websocket.Send($"{Constants.Mod.TrainingMapCvar} {trainingMap}{Constants.Mod.MapSuffix}");
        }

        private void OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Data == "authyes")
            {
                _authenticated = true;
            }
        }

        private void Authenticate()
        {
            _websocket.Send($"rcon_password {Constants.RCON.Password}");
        }
    }
}