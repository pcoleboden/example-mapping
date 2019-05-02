using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Boden.Tools.ExampleMapping.Hubs
{
    public class TestHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
