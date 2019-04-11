namespace Instant.Training.UI.Utilities
{
    using WebSocketSharp;

    public class WebSocketAdapter : WebSocket, IWebSocket
    {
        public WebSocketAdapter(string url, params string[] protocols) : base(url, protocols)
        {
        }
    }
}