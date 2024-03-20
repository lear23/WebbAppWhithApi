using Microsoft.AspNetCore.Mvc;

namespace SiliconWebApp.Controllers;



[Route("/contact")]
public class ContactController : Controller
{
    public IActionResult Contact()
    {
        return View();
    }
}
