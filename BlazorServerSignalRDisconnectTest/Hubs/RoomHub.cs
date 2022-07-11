using Microsoft.AspNetCore.SignalR;

namespace BlazorServerSignalRDisconnectTest.Hubs
{
    public class RoomHub : Hub
    {
        private static int ConnectedUsers = 0;

        public async override Task OnConnectedAsync()
        {
            ConnectedUsers++;

            Console.WriteLine($"Connecting: {Context.ConnectionId}");

            await Clients.All.SendAsync("UserCountChanged", ConnectedUsers);
            await base.OnConnectedAsync();
        }
        public async override Task OnDisconnectedAsync(Exception? exception)
        {
            ConnectedUsers--;

            Console.WriteLine($"Disconnecting: {Context.ConnectionId}");

            await Clients.All.SendAsync("UserCountChanged", ConnectedUsers);
            await base.OnDisconnectedAsync(exception);
        }
    }
}

