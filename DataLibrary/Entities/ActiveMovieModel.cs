using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Entities;

public class ActiveMovieModel
{
    [Key]
    [Required]
    public int Id { get; set; }
    public int SaloonModelId { get; set; }
    public int MovieModelId { get; set; }
    public int TimeModelId { get; set; }
    [DataType(DataType.Currency)]
    public int Price { get; set; }

    public virtual SaloonModel SaloonModel { get; set; }
    public virtual MovieModel MovieModel { get; set; }
    public virtual TimeModel TimeModel { get; set; }
}
