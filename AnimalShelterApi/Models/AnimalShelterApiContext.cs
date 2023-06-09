using Microsoft.EntityFrameworkCore;

namespace AnimalShelterApi.Models
{
  public class AnimalShelterApiContext : DbContext
  {
    public DbSet<Animal> Animals { get; set; }
    public DbSet<User> Users { get; set; }

    public AnimalShelterApiContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Animal>()
        .HasData(
          new Animal { AnimalId = 1, Name = "Scratchy", Type = "Cat", Breed="Scruffy", Available=true, DateAdmitted = new DateTime(2018, 3, 1)},
          new Animal { AnimalId = 2, Name = "Cranko", Type = "Dog", Breed="Beagle/Sneaky", Available=true, DateAdmitted = new DateTime(2022, 5, 11)},
          new Animal { AnimalId = 3, Name = "Sporty", Type = "Bird", Breed="Feathered", Available=false, DateAdmitted = new DateTime(2020, 12, 31)},
          new Animal { AnimalId = 4, Name = "Stanley", Type = "Dog", Breed="Foxhound", Available=true, DateAdmitted = new DateTime(2022, 4, 23)},
          new Animal { AnimalId = 5, Name = "Borgus", Type = "Cat", Breed="Tabby/Stinky", Available=true, DateAdmitted = new DateTime(2022, 6, 2)}
        );
      builder.Entity<User>()
        .HasData(
          new User { UserId=1, Username="gogorobinson", EmailAddress = "gogo@rob.com", Password = "eggs", GivenName = "Gogo", Surname = "Robinson", Role = "Adminstrator"},
          new User { UserId = 2, Username="stever", EmailAddress = "stever@rob.com", Password = "eggs2", GivenName = "Stever", Surname = "Scorpion", Role = "Standard"},
          new User { UserId = 3, Username="dread", EmailAddress = "dread@rob.com", Password = "eggs3", GivenName = "Dread", Surname = "Veil", Role = "Standard"}
        );
    }
  }
}