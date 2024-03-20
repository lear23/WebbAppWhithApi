using Microsoft.AspNetCore.Mvc;

namespace SiliconWebApp.Controllers;

public class CoursesController : Controller
{
    public IActionResult Courses()
    {
        return View();
    }
}
