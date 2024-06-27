using BLL.DataObjectTransforms;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VL.Pages.Rooms;

public class Add : PageModel
{
    [BindProperty] public RoomCreateRequest Room { get; set; }
    private readonly IRoomService _roomService;
    
    public Add(IRoomService roomService)
    {
        _roomService = roomService;
    }

    public void OnGet()
    {
    }
    
    public IActionResult OnPost()
    {
        _roomService.Add(Room);
        return RedirectToPage("/Rooms/Index");
    }
}