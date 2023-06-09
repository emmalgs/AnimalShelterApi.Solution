using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AnimalShelterApi.Models
{
  public class AnimalShelterApiContext : IdentityDbContext<User>
  {
    public DbSet<Animal> Animals { get; set; }
    public DbSet<SavedAnimal> SavedAnimals { get; set; }

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

        base.OnModelCreating(builder);
        builder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.HasKey(x => x.UserId);
        });
    }
  }
}