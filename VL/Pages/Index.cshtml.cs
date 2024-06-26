using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VL.Pages;

public class IndexModel : PageModel
{
    private readonly RoomService _roomService;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger, RoomService roomService)
    {
        _logger = logger;
        _roomService = roomService;
    }

    public async Task OnGetAsync()
    {
        IEnumerable<RoomInformation> roomInformations = null;
        roomInformations = await _roomService.AllAsync();
        ViewData["RoomInformations"] = roomInformations; // Pass the data to the view
    }
}