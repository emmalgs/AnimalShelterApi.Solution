namespace AnimalShelterApi.Models
{
  public class User
  {
    public int UserId { get; set; }
    public string Username { get; set; }
    public List<SavedAnimal> SavedAnimals { get; set; }
  }
}