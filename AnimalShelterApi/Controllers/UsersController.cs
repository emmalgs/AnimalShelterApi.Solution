using AnimalShelterApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelterApi.Controllers
{
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiController]
  [ApiVersion("1.0")]

  public class UsersController : ControllerBase
  {
    private readonly AnimalShelterApiContext _db;

    public UsersController(AnimalShelterApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<List<User>> Get(string username)
    {
      IQueryable<User> query = _db.Users 
                                    .Include(user => user.SavedAnimals)
                                    .AsQueryable();
      if (username != null)
      {
        query = query.Where(entry => entry.Username == username);
      }

      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
      User user = await _db.Users
                            .Include(u => u.SavedAnimals)
                            .FirstOrDefaultAsync(u => u.UserId ==id);

      if (user == null)
      {
        return NotFound();
      }
      return user;
    }

    [HttpPost]
    public async Task<ActionResult<User>> Post(User user)
    {
      _db.Users.Add(user);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetUser), new { id = user.UserId}, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, User user)
    {
      if (id != user.UserId)
      {
        return BadRequest();
      }

      _db.Users.Update(user);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!UserExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    private bool UserExists(int id)
    {
      return _db.Users.Any(e => e.UserId == id);
    }
  }
}
