using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

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





    //public IActionResult Subscribe()
    //{
    //    ViewData["Subscribed"] = false;
    //    return View();
    //}



    [HttpPost]
    public async Task<IActionResult> Home(SubscriberEntity model)
    {
        if (ModelState.IsValid)
        {
            using var http = new HttpClient();
            var json = JsonConvert.SerializeObject(model);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await http.PostAsync($"https://localhost:7071/api/Subscriber?email={model.Email}", content);
            if (response.IsSuccessStatusCode)
            {
                ViewData["Subscribed"] = true;

                return RedirectToAction("Home");
            }
        }
        return View(); 
    }
}
