using Microsoft.AspNetCore.Identity;

namespace AnimalShelterApi.Models
{
  public class User : IdentityUser
  {
    public List<SavedAnimal> SavedAnimals { get; set; }
  }
}