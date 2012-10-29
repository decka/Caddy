using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR;
using Caddy.Server;
using System.Threading.Tasks;

namespace Caddy.WebServer
{
    public class CaddyEndpoint : PersistentConnection
    {
        public void SendClientDTO(ClientDTO clientDTO)
        {
            //Clients[clientDTO.Client.ConnectionID].addMessage(clientDTO.PurchaseDTO);
        }

        protected override Task OnConnectedAsync(IRequest request, string connectionId)
        {
            return Connection.Broadcast("Connection " + connectionId + " connected");
        }

    }
}