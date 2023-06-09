using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelterApi.Models;

namespace AnimalShelterApi.Controllers
{
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiController]
  [ApiVersion("1.0")]

  public class AnimalsController: ControllerBase
  {
    private readonly AnimalShelterApiContext _db;
    public AnimalsController(AnimalShelterApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<List<Animal>> Get(string name, string type, string breed, DateTime? date = null, bool? available = null)
    {
      IQueryable<Animal> query = _db.Animals
                                    .AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      if (type != null)
      {
        query = query.Where(entry => entry.Type == type);
      }
      if (breed != null)
      {
        query = query.Where(entry => entry.Breed == breed);
      }
      if (date.HasValue)
      {
        query = query.Where(entry => entry.DateAdmitted == date);
      }
      if (available.HasValue)
      {
        query = query.Where(entry => entry.Available == available);
      }

      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Animal>> GetAnimal(int id)
    {
      Animal animal = await _db.Animals.FirstOrDefaultAsync(a => a.AnimalId == id);

      if (animal == null)
      {
        return NotFound($"Animal at id {id} does not exist");
      }

      return animal;
    }

    [HttpPost]
    public async Task<ActionResult<Animal>> Post(Animal animal)
    {
      _db.Animals.Add(animal);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetAnimal), new { id = animal.AnimalId }, animal);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Animal animal)
    {
      if (id != animal.AnimalId)
      {
        return BadRequest();
      }
      _db.Animals.Update(animal);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AnimalExists(id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimal(int id)
    {
      Animal animal = await _db.Animals.FindAsync(id);
      if (animal == null)
      {
        return NotFound();
      }

      _db.Animals.Remove(animal);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    private bool AnimalExists(int id)
    {
      return _db.Animals.Any(e => e.AnimalId == id);
    }
  }
}