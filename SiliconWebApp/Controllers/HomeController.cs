using Microsoft.AspNetCore.Mvc;

namespace SiliconWebApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Home()
    {
        return View();
    }

    public IActionResult Error404(int statusCode)
    {
        return View();
    }


}
