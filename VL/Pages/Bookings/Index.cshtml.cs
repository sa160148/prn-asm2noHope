using BLL.DataObjectTransforms;
using BLL.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using VL.Hubs;

namespace VL.Pages.Bookings;

public class Index : PageModel
{
    private readonly IHubContext<SystemR> _hubContext;
    private readonly IBookingService? _bookingService;
    private readonly IBookingDetailService _bookingDetailService;

    public Index(IBookingDetailService bookingDetailService, IBookingService? bookingService, IHubContext<SystemR> hubContext)
    {
        _bookingDetailService = bookingDetailService;
        _bookingService = bookingService;
        _hubContext = hubContext;
    }

    public List<BookingDetailResponse> BookingDetails { get; set; }
    
    public async Task OnGet()
    {
        BookingDetails = await _bookingDetailService.GetAll();
    }
}