using System;
using System.ComponentModel.DataAnnotations;

namespace EluneApi.Models
{
  public class Baby
  {
    public int BabyId { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters long.")]
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }

    public ICollection<SleepTime> SleepTimes { get; set; }

  }

  public class SleepTime
  {
      public int SleepTimeId { get; set; }
      public DateTime StartTime { get; set; }
      public DateTime EndTime { get; set; }

      public int BabyId { get; set; }
      public Baby Baby { get; set; }

      public TimeSpan ElapsedTime
      {
        get
        {
          return EndTime - StartTime;
        }
      }
  }
}