using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocketSharp;

namespace MainPrj.Util
{
    /// <summary>
    /// Web socket utility class.
    /// </summary>
    public static class WebSocketUtility
    {
        /// <summary>
        /// Web socket server url.
        /// </summary>
        public const string WEBSOCKET_SERVER_URL = "ws://io.huongminhgroup.com:8004/user_id={0}&huongminh_token={1}&agent_id={2}";
        /// <summary>
        /// Web socket server port.
        /// </summary>
        public const string WEBSOCKET_SERVER_PORT = "8004";
        /// <summary>
        /// Start connect with server.
        /// </summary>
        /// <param name="openHandler">Handle open connect</param>
        /// <param name="errorHanlder">Handle error</param>
        /// <param name="messageHandler">Handle receive message</param>
        /// <param name="closeHandler">Handle close connect</param>
        public static void StartWebSocket(EventHandler openHandler, EventHandler<ErrorEventArgs> errorHanlder,
            EventHandler<MessageEventArgs> messageHandler, EventHandler<CloseEventArgs> closeHandler)
        {
            // User login already
            if (DataPure.Instance.User != null)
            {
                // Send agent id if user is accounting, empty string otherwise
                string agent_id = DataPure.Instance.IsAccountingAgentRole() ?
                    DataPure.Instance.Agent.Id : string.Empty;

                // Set url for web socket object and create object
                DataPure.Instance.WebSocket = new WebSocketSharp.WebSocket(String.Format(WEBSOCKET_SERVER_URL,
                    DataPure.Instance.User.User_id,
                    Properties.Settings.Default.UserToken, agent_id));

                // Set event handler
                DataPure.Instance.WebSocket.OnOpen    += openHandler;
                DataPure.Instance.WebSocket.OnError   += errorHanlder;
                DataPure.Instance.WebSocket.OnMessage += messageHandler;
                DataPure.Instance.WebSocket.OnClose   += closeHandler;

                // Start connect
                DataPure.Instance.WebSocket.ConnectAsync();
                DataPure.Instance.IsCloseWebSocketConnection = false;
            }
            else
            {
                CommonProcess.ShowErrorMessage(Properties.Resources.NotLoginYet);
            }
        }
    }
}
