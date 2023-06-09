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


  }
}
