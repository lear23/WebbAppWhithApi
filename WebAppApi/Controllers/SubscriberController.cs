using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAppApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscriberController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    #region CREATE
    [HttpPost]
    public async  Task<IActionResult> Create(string email)
    {
        if (!string.IsNullOrEmpty(email))
        {
            if (!await _context.Subscrivers.AnyAsync(x => x.Email == email))
            {
                try
                {
                    var subscriberEntity = new SubscriberEntity { Email = email };
                    _context.Subscrivers.Add(subscriberEntity);
                    await _context.SaveChangesAsync();

                    return Created("", null);
                }
                catch
                {
                    return Problem("Unable to create subscription");
                }
            }
            return Conflict("This email address is already subscribed");
        }
        return BadRequest();
    }

    #endregion


    #region GET

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var subscriber = await _context.Subscrivers.ToListAsync();  
        if (subscriber.Count != 0)
        {
            return Ok(subscriber);
        }

        return NotFound();
    }

    [HttpGet ("{email}")]
    public async Task<IActionResult> GetOne(string email)
    {
        var subscriber = await _context.Subscrivers.FirstOrDefaultAsync(x => x.Email == email);

        if (subscriber != null)
        {
            return Ok(subscriber);
        }
        return NotFound();
    }

    #endregion


    #region Update
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, string email)
    {
        var subscriber = await _context.Subscrivers.FirstOrDefaultAsync(x => x.Id == id);

        if (subscriber != null)
        {

            subscriber.Email = email;
            _context.Subscrivers.Update(subscriber);
            await _context.SaveChangesAsync();

            return Ok(subscriber);
        }
        return NotFound();
    }

    #endregion


    #region DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var subscriber = await _context.Subscrivers.FirstOrDefaultAsync(x => x.Id == id);

        if (subscriber != null)
        {
          
            _context.Subscrivers.Remove(subscriber);
            await _context.SaveChangesAsync();

            return Ok();
        }
        return NotFound();
    }

    #endregion

}
