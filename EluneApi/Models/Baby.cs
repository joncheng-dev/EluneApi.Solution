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
    public ICollection<FeedingTime> FeedingTimes { get; set; }
    public ICollection<BathroomTime> BathroomTimes { get; set; }
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

  public class FeedingTime
  {
    public int FeedingTimeId { get; set; }
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

  public class BathroomTime
  {
    public int BathroomTimeId { get; set; }
    public DateTime Timestamp { get; set; }
    public bool IsPee { get; set; }
    public bool IsPoo { get; set; }
    
    public int BabyId { get; set; }
    public Baby Baby { get; set; }
  }    
}