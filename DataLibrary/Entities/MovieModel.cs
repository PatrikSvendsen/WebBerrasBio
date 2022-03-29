using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Entities;

public class MovieModel
{
    public int Id { get; set; }
    [Display(Name = "Movie Title")]
    public string Title { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime ReleaseDate { get; set; }

    public string Genre { get; set; }
    public bool IsActive { get; set; }
}
