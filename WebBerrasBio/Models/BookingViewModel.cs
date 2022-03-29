using System.ComponentModel.DataAnnotations;

namespace WebBerrasBio.Models
{
    public class BookingViewModel
    {
        [Key]
        [Required]
        public int BookingViewModelId { get; set; }

        [Display(Name = "First name")]
        [Required(ErrorMessage = "This need to be filled out!")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "This need to be filled out!")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
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
        public string Title { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }

    }
}
