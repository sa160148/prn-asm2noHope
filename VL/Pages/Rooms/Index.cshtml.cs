using DAL.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VL.Pages.Rooms;

public class Index : PageModel
{
    private List<RoomInformation> RoomInformations { get; set; } = default!;
    public void OnGet()
    {
        
    }
}