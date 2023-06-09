using AnimalShelterApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelterApi.Controllers
{
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiController]
  [ApiVersion("1.0")]
  public class SavedAnimalsController : ControllerBase
  {
    private readonly AnimalShelterApiContext _db;

    public SavedAnimalsController(AnimalShelterApiContext db)
    {
      _db = db;
    }

    [HttpPost]
    public async Task<ActionResult<SavedAnimal>> PostSavedAnimal(SavedAnimal savedAnimal)
    {
      Animal animal = await _db.Animals 
                                .Include(a => a.SavedAnimals)
                                .FirstOrDefaultAsync(a => a.AnimalId == savedAnimal.AnimalId);
      
      User user = await _db.Users
                            .Include(u => u.SavedAnimals)
                            .FirstOrDefaultAsync(u => u.UserId == savedAnimal.UserId);

      if (animal == null)
      {
        return NotFound("Animal does not exist in database");
      }
      else if (user == null)
      {
        return NotFound("User does not exist in database");
      }
      else
      {
        _db.SavedAnimals.Add(savedAnimal);
        await _db.SaveChangesAsync();
        user.SavedAnimals.Add(savedAnimal);
        animal.SavedAnimals.Add(savedAnimal);
        await _db.SaveChangesAsync();

        return NoContent();
      }

    }
  }
}