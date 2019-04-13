namespace Instant.Training.UI.Services
{
    using System;

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

        public void ToggleModEnabled(bool enabled)
        {
            _websocket.Send($"{Constants.Mod.EnabledCvar} {Convert.ToInt32(enabled)}");
        }

        public void TransmitTrainingMap(string trainingMap)
        {
            _websocket.Send($"{Constants.Mod.TrainingMapCvar} {trainingMap}");
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