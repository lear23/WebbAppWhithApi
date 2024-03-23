using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiliconWebApp.ViewModels.Courses;

namespace SiliconWebApp.Controllers;

//[Authorize]

public class CoursesController(HttpClient httpClient) : Controller
{
    private readonly HttpClient _httpClient = httpClient;


    public async Task<IActionResult> Courses()
    {
        var viewModel = new CoursesViewModel();


        var response = await _httpClient.GetAsync("https://localhost:7071/api/courseApi");
      

        viewModel.CourseModels = JsonConvert.DeserializeObject<IEnumerable<CourseModel>>(await response.Content.ReadAsStringAsync())!;

        return View(viewModel);
    }
}
