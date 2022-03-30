using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Entities;
/// <summary>
/// En model-class för hantera filmer som finns att visa. Inget att förknippa med "ActiveMovieModel". 
/// Denna model tar endast hand om filmer och dess information.
/// </summary>
public class MovieModel
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Title { get; set; }
    [DataType(DataType.DateTime)]
    [Display(Name = "Releasedate")]
    public DateTime ReleaseDate { get; set; }
    public string Genre { get; set; }
    public bool IsActive { get; set; }
}
