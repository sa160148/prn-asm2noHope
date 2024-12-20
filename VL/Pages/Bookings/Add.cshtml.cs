using BLL.DataObjectTransforms;
using BLL.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using VL.Hubs;

namespace VL.Pages.Bookings;

public class Add : PageModel
{
    public Add(IBookingService bookingService, IHubContext<SystemR> hubContext)
    {
        _bookingService = bookingService;
        _hubContext = hubContext;
    }

    public BookingCreatingResponse Booking { get; set; }
    
    private readonly IBookingService _bookingService;
    private readonly IHubContext<SystemR> _hubContext;
    public void OnGet(int roomId)
    {
        Booking = _bookingService.CreatingBookARoom(roomId);
    }
    public async Task OnPost(int userId, int rumId, string end)
    {
        await _bookingService.BookARoom(roomId: rumId, userId, end);
        await _hubContext.Clients.All.SendAsync("LoadBookings");
    }
}