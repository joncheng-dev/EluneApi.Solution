using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EluneApi.Models
{
  public class EluneApiContext : DbContext
  {
    public DbSet<Baby> Babies { get; set; }
    public DbSet<SleepTime> SleepTimes { get; set; }
    public DbSet<FeedingTime> FeedingTimes { get; set; }
    public DbSet<BathroomTime> BathroomTimes { get; set; }

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

        builder.Entity<SleepTime>()
        .HasData(
            new SleepTime { SleepTimeId = 1, StartTime = new DateTime(2024, 7, 1, 20, 0, 0, DateTimeKind.Utc), EndTime = new DateTime(2024, 7, 2, 5, 0, 0, DateTimeKind.Utc), BabyId = 1 },
            new SleepTime { SleepTimeId = 2, StartTime = new DateTime(2024, 7, 2, 21, 30, 0, DateTimeKind.Utc), EndTime = new DateTime(2024, 7, 3, 6, 0, 0, DateTimeKind.Utc), BabyId = 1 },
            new SleepTime { SleepTimeId = 3, StartTime = new DateTime(2024, 7, 3, 22, 0, 0, DateTimeKind.Utc), EndTime = new DateTime(2024, 7, 4, 6, 0, 0, DateTimeKind.Utc), BabyId = 2 },
            new SleepTime { SleepTimeId = 4, StartTime = new DateTime(2024, 7, 2, 19, 0, 0, DateTimeKind.Utc), EndTime = new DateTime(2024, 7, 3, 4, 0, 0, DateTimeKind.Utc), BabyId = 3 },
            new SleepTime { SleepTimeId = 5, StartTime = new DateTime(2024, 7, 2, 23, 0, 0, DateTimeKind.Utc), EndTime = new DateTime(2024, 7, 3, 7, 0, 0, DateTimeKind.Utc), BabyId = 4 },
            new SleepTime { SleepTimeId = 6, StartTime = new DateTime(2024, 7, 3, 0, 0, 0, DateTimeKind.Utc), EndTime = new DateTime(2024, 7, 3, 8, 0, 0, DateTimeKind.Utc), BabyId = 5 }
        );
    }
  }
}