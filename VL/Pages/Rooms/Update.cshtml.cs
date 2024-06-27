using BLL.DataObjectTransforms;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VL.Pages.Rooms;

public class Update : PageModel
{
    private readonly IRoomService _roomService;
    public RoomModifyRequest Room { get; set; }
    public Update(IRoomService roomService)
    {
        _roomService = roomService;
    }

    public void OnGet(int id)
    {
        Room eRoom = _roomService.GetId(id);
    }
}