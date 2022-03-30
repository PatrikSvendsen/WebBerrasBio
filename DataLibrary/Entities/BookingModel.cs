using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLibrary.Entities;
/// <summary>
/// En model-class för hantering av booking inputs. Finns dessutom FK koppling samt en icke-mappad property "Name". 
/// </summary>
public class BookingModel
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public int ActiveMovieModelId { get; set; }
    [Display(Name = "Tickets")]
    public int BookedTickets { get; set; }


    public virtual ActiveMovieModel? ActiveMovieModel { get; set; }

    [Display(Name = "Name")]
    [NotMapped]
    public string FullName { get { return FirstName + " " + LastName; } }


}
