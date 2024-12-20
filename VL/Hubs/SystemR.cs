using Microsoft.AspNetCore.SignalR;

namespace VL.Hubs;

public class SystemR : Hub<ISystemR>
{
    /*public override async Task OnConnectedAsync()
    {
        #region Config

        /*await Clients.All.SendLoadRoom("LoadRooms");
        await Clients.All.SendLoadBooking("LoadBookings");#1#

        #endregion
        
        await base.OnConnectedAsync();
    }*/
}
public interface ISystemR
{
    /*public Task SendLoadRoom(string message);
    public Task SendLoadBooking(string message);*/
}