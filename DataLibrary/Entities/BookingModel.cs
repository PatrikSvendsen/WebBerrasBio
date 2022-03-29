using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLibrary.Entities;

public class BookingModel
{
    public int Id { get; set; }
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
    [Display(Name = "Email")]
    public string EmailAddress { get; set; }
    public int ActiveMovieModelId { get; set; }
    [Range(1, 12, ErrorMessage = "Minimum: 1 ticket. Maximum 12 tickets")]
    [Display(Name = "Tickets")]
    public int BookedTickets { get; set; }

    
    public virtual ActiveMovieModel? ActiveMovieModel { get; set; }
    
    [Display(Name = "Name")]
    [NotMapped]
    public string FullName { get { return FirstName + " " + LastName; } }
    
    
}
