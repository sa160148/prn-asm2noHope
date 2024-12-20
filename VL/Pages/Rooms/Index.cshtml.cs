using BLL.DataObjectTransforms;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using VL.Hubs;

namespace VL.Pages.Rooms;

public class Index : PageModel
{
    private readonly IRoomService _roomService;
    private readonly IHubContext<SystemR> _hubContext;
    /*
    [BindProperty] public int PageSize { get; set; } = 3;
    public int TotalPages { get; set; }
    [BindProperty] public int CurrentPage { get; set; } = 1;
    */
    

    public Index(IRoomService roomService, IHubContext<SystemR> hubContext)
    {
        _roomService = roomService;
        _hubContext = hubContext;
    }
    
    public void OnGet()
    {
        
    }
}