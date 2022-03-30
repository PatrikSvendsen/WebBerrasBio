using System.ComponentModel.DataAnnotations;

namespace WebBerrasBio.Models
{
    /// <summary>
    /// En model som enbart är skapat för vy-visning och validering av input data
    /// </summary>
    public class BookingViewModel
    {
        [Key]
        [Required]
        public int BookingViewModelId { get; set; }

        [Display(Name = "First name")]
        [Required(ErrorMessage = "This need to be filled out!")]
        public string FirstName { get; set; } 

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "This need to be filled out!")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "This is not a valid email address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Movie")]
        [Required]
        public int ActiveMovieModelId { get; set; }

        [Display(Name = "Tickets")]
        [Range(1, 12, ErrorMessage = "Minimum: 1 ticket. Maximum 12 tickets")]
        [Required]
        public int BookedTickets { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Releasedate")]
        public DateTime ReleaseDate { get; set; }

        public string Title { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }

    }
}
