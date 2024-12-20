using BLL.DataObjectTransforms;
using BLL.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using VL.Hubs;

namespace VL.Pages;

public class IndexModel : PageModel
{
    private readonly RoomService _roomService;
    private readonly ILogger<IndexModel> _logger;
    private readonly IHubContext<SystemR> _hubContext;

    public List<RoomsPageResponse> Rooms { get; set; }
    public IndexModel(ILogger<IndexModel> logger, RoomService roomService, IHubContext<SystemR> hubContext)
    {
        _logger = logger;
        _roomService = roomService;
        _hubContext = hubContext;
    }

    public async Task OnGet()
    {
        Rooms = await _roomService.AllAsync();
    }
}