namespace AnimalShelterApi.Models
{
  public class Animal
  {
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd}", ApplyFormatInEditMode=true)]
    public int AnimalId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Breed { get; set; }
    public bool Available { get; set; }
    public DateTime DateAdmitted { get; set; }
    public List<SavedAnimal> SavedAnimals { get; set; }
  }
}