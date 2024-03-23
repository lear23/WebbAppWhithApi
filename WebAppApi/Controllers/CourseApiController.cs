using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppApi.Dtos;

namespace WebAppApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseApiController(AppDbContext appDbContext) : ControllerBase
{

    private readonly AppDbContext _appDbContext = appDbContext;

    [HttpPost]
    public async Task<IActionResult> create(CourseDto dto)
    {

        if (ModelState.IsValid)
        {
            if (!await _appDbContext.Courses.AnyAsync(x => x.Title == dto.Title))
            {
                var courseEntity = new CourseEntity
                {
                    Title = dto.Title,
                    Author = dto.Author,
                    IsBestSeller = dto.IsBestSeller,
                    Discount = dto.Discount,
                    Price = dto.Price,
                    Hours = dto.Hours,
                    LikesNumbers = dto.LikesNumbers,
                    LikesProcent = dto.LikesProcent,
                    ImageName = dto.ImageName
                };
                _appDbContext.Courses.Add(courseEntity);
                await _appDbContext.SaveChangesAsync();

                return Created("", null);

            }
            return Conflict();
        }
        return BadRequest();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var courses = await _appDbContext.Courses.ToListAsync();
        return Ok(courses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(string id)
    {
        var courseEntity = await _appDbContext.Courses.FirstOrDefaultAsync(x => x.Id == id);
        if (courseEntity != null)
        {
            return Ok(courseEntity);
        }
        return NotFound();
    }


}
