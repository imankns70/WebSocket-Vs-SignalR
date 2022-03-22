using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace WebSocketServer.Middleware
{
    public class WebSocketServerConnectionManager
    {
        private ConcurrentDictionary<string, WebSocket> _socket = new ConcurrentDictionary<string, WebSocket>();

        public ConcurrentDictionary<string, WebSocket> GetAllSockets()
        {
            return _socket;
        }

        public string AddSocket(WebSocket socket)
        {
            string connID = Guid.NewGuid().ToString();
            _socket.TryAdd(connID, socket);
            Console.WriteLine("Connection Added:" + connID);
            return connID;
        }
    }
}
