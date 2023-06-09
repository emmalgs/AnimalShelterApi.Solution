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

    [HttpGet]
    public async Task<List<SavedAnimal>> GetSavedAnimals(int animalId, int userId, string animalName, string userName)
    {
      IQueryable<SavedAnimal> query = _db.SavedAnimals.AsQueryable();

      if (animalId > 0)
      {
        query = query.Where(e => e.AnimalId == animalId);
      }
      if (userId > 0)
      {
        query = query.Where(e => e.UserId == userId);
      }
      if (animalName != null)
      {
        Animal thisAnimal = await _db.Animals.FirstOrDefaultAsync(a => a.Name == animalName);
        query = query.Where(e => e.AnimalId == thisAnimal.AnimalId);
      }
      if (userName != null)
      {
        User thisUser = await _db.Users.FirstOrDefaultAsync(a => a.Username == userName);
        query = query.Where(e => e.UserId == thisUser.UserId);
      }

      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SavedAnimal>> GetSavedAnimal(int id)
    {
      SavedAnimal entry = await _db.SavedAnimals.FirstOrDefaultAsync(e => e.SavedAnimalId == id);
      if (entry == null)
      {
        return NotFound($"post at id {id} not found");
      }

      return entry;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, SavedAnimal entry)
    {
      if (entry.SavedAnimalId != id)
      {
        return BadRequest();
      }

      _db.SavedAnimals.Update(entry);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!SavedAnimalExists(id))
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

    private bool SavedAnimalExists(int id)
    {
      return _db.SavedAnimals.Any(e => e.SavedAnimalId == id);
    }
  }
}