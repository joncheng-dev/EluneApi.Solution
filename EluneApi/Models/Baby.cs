using System.ComponentModel.DataAnnotations;

namespace EluneApi.Models
{
  public class Baby
  {
    public int BabyId { get; set; }
    [Required]
    [StringLength(2, 50, ErrorMessage = "Name must be between 2 and 50 characters long.")]
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
  }
}