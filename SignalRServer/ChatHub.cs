using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace SignalRServer
{
    public class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("--> Connection Established :" + Context.ConnectionId);

            Clients.Client(Context.ConnectionId).SendAsync("ReceiveConnID :", Context.ConnectionId);

            return base.OnConnectedAsync();

        }

        public async Task SendMessageAsync(string message)
        {
            var routeOb = JsonConvert.DeserializeObject<dynamic>(message);

            string toCLient = routeOb.To;

            Console.WriteLine("--> Message Received on:" + Context.ConnectionId);

            if (string.IsNullOrEmpty(toCLient))
            {
                await Clients.All.SendAsync("ReceiveMessage", message);
            }
            else
            {
                await Clients.Client(toCLient).SendAsync("ReceiveMessage", message);
            }


        }
    }
}
