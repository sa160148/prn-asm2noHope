using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VL.Pages;

public class IndexModel : PageModel
{
    private readonly RoomInformationService _roomService;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger, RoomInformationService roomService)
    {
        _logger = logger;
        _roomService = roomService;
    }

    public void OnGet()
    {
        IEnumerable<RoomInformation> roomInformations = null;
    }
}