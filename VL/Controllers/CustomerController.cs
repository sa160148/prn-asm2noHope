using Microsoft.AspNetCore.Mvc;

namespace VL.Controllers;

public class CustomerController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}