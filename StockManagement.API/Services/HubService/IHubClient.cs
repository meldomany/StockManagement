using Microsoft.AspNetCore.SignalR;

namespace StockManagement.API.Services.HubService
{
    public interface IHubClient
    {
        Task BroadcastMessage();
    }

    public class BroadcastHub : Hub<IHubClient>
    {
    }
}
