namespace Instant.Training.UI.Utilities
{
    using System;

    using WebSocketSharp;

    public interface IWebSocket
    {
        event EventHandler<MessageEventArgs> OnMessage;

        void Connect();

        void Send(string message);
    }
}