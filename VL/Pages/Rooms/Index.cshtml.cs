using BLL.DataObjectTransforms;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VL.Pages.Rooms;

public class Index : PageModel
{
    private readonly IRoomService _roomService;
    [BindProperty] public int PageSize { get; set; } = 3;
    
    public int TotalPages { get; set; }
    
    [BindProperty]
    public int CurrentPage { get; set; } = 1;

    public Index(IRoomService roomService)
    {
        _roomService = roomService;
    }
    
    public void OnGet()
    {
    }
}