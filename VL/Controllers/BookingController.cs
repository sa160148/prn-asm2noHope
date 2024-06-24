using Microsoft.AspNetCore.Mvc;

namespace VL.Controllers;

public class BookingController : Controller
{
    // GET
    [HttpGet]
    public IActionResult Add()
    {
        return Ok(); 
    }
}