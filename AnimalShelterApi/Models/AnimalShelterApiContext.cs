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
          new Animal { AnimalId = 1, Name = "Scratchy", Type = "Cat", Breed="Scruffy", Available=true, DateAdmitted = "2018-02-01" },
          new Animal { AnimalId = 2, Name = "Cranko", Type = "Dog", Breed="Beagle/Sneaky", Available=true, DateAdmitted = "2022-03-12" },
          new Animal { AnimalId = 3, Name = "Sporty", Type = "Bird", Breed="Feathered", Available=false, DateAdmitted = "2022-07-28" },
          new Animal { AnimalId = 4, Name = "Stanley", Type = "Dog", Breed="Foxhound", Available=true, DateAdmitted = "2021-01-18" },
          new Animal { AnimalId = 5, Name = "Borgus", Type = "Cat", Breed="Tabby/Stinky", Available=true, DateAdmitted = "2022-09-22" }

        );

        base.OnModelCreating(builder);
        builder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.HasKey(x => x.UserId);
        });
    }
  }
}