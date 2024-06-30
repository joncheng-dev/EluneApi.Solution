using System;
using System.ComponentModel.DataAnnotations;

namespace EluneApi.Models
{
  public class Baby
  {
    public int BabyId { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 5)]
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
  }
}