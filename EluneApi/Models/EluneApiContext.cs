using Microsoft.EntityFrameworkCore;

namespace EluneApi.Models
{
  public class EluneApiContext : DbContext
  {
    public DbSet<Baby> Babies { get; set; }

    public EluneApiContext(DbContextOptions<EluneApiContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Baby>()
        .HasData(
          new Baby { BabyId = 1, Name = "Stewie Griffin", BirthDate = new DateTime(2024, 5, 10, 0, 0, 0, DateTimeKind.Utc)},
          new Baby { BabyId = 2, Name = "Maggie Simpson", BirthDate = new DateTime(2024, 6, 20, 0, 0, 0, DateTimeKind.Utc)},
          new Baby { BabyId = 3, Name = "Tommy Pickles", BirthDate = new DateTime(2024, 4, 05, 0, 0, 0, DateTimeKind.Utc)},
          new Baby { BabyId = 4, Name = "Baby Groot", BirthDate = new DateTime(2024, 6, 17, 0, 0, 0, DateTimeKind.Utc)},
          new Baby { BabyId = 5, Name = "Scrappy Doo", BirthDate = new DateTime(2024, 4, 08, 0, 0, 0, DateTimeKind.Utc)}
        );
    }
  }
}