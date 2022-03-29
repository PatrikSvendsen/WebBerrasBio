using DataLibrary.Entities;
using DataLibrary.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebBerrasBio.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IActiveMovieService _activeMovieService;
        private readonly ISaloonService _saloonService;
        private readonly ISeatService _seatService;

        public BookingController(IBookingService bookingService,
            IActiveMovieService activeMovieService, ISaloonService saloonService, ISeatService seatService)
        {
            _bookingService = bookingService;
            _activeMovieService = activeMovieService;
            _saloonService = saloonService;
            _seatService = seatService;
        }

        //GET
        [HttpGet]
        public IActionResult Create(int? activeMovieModelId)
        {
            if (activeMovieModelId == null)
            {
                return NotFound();
            }
            var activeMovie = _activeMovieService.GetActiveMovieByID(activeMovieModelId);
            TempData["price"] = activeMovie.Price;      //TODO Behöver fixas. Pris försvinner om man uppdaterar sidan.
            //ViewBag.ActiveMovie = activeMovie;        ////TODO Vill inte fungera korrekt, sidan kraschar. Något med IEnum
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,FirstName,LastName,EmailAddress,ActiveMovieModelId,bookedTickets")]
                                                    int? activeMovieModelId, BookingModel bookingModels)
        {
            if (activeMovieModelId == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                int bookingId;
                var activeMovieModel = _activeMovieService.GetActiveMovieByID(activeMovieModelId);
                var saloon = _saloonService.GetSaloonByID(activeMovieModel.SaloonModelId);
                bool isFull = _bookingService.CheckAvailableSeats(saloon.AvailableSeats, bookingModels.BookedTickets);
                if (isFull == true)
                {
                    ViewBag.Full = $"Full, there is only {saloon.AvailableSeats} left ";
                    return View();
                }
                _saloonService.AdjustAvailableToBookedSeats(saloon, bookingModels);
                _bookingService.InsertBooking(bookingModels);
                _bookingService.Save();                         //TODO Vill gärna få detta fixat så att man inte behöver spara innan. Något med FK
                _seatService.UpdateSeat(bookingModels.BookedTickets, bookingModels.Id);
                _seatService.Save();
                return RedirectToAction("ListView", "ActiveMovie");
            }
            return View();
        }

        //GET
        [HttpGet]
        public IActionResult ListView()
        {
            var checkBookings = _bookingService.GetDetailedBookingList();
            return View(checkBookings);
        }
        // GET
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bookingToDelete = _bookingService.GetDetailedBookingList()
                .FirstOrDefault(x => x.Id == id);
            if (bookingToDelete == null)
            {
                return NotFound();
            }
            return View(bookingToDelete);
        }
        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] //TODO Kontrollera så att denna finns där den behövs. Här och i html-filen
        public IActionResult Delete(int id)
        {
            var booking = _bookingService.GetBookingByID(id);
            var activeMovie = _activeMovieService.GetActiveMovieByID(booking.ActiveMovieModelId);
            var saloon = _saloonService.GetSaloonByID(activeMovie.SaloonModelId);
            _saloonService.AdjustAvailableBookedSeatsWhenDelete(saloon, booking);
            _seatService.DeUpdateSeats(id);
            _bookingService.DeleteBooking(id);
            _seatService.Save();
            return RedirectToAction(nameof(ListView));
        }

        [HttpGet] // Ingen snygg men get shits done.
        public ActionResult DeleteAll()
        {
            var bookingList = _bookingService.GetDetailedBookingList();
            if (bookingList.Count == 0)
            {
                return RedirectToAction(nameof(ListView));
            }
            foreach (var booking in bookingList)
            {
                _bookingService.DeleteBooking(booking.Id);
            }
            var seatReset = _seatService.GetSeats();
            foreach (var seat in seatReset)
            {
                seat.IsBooked = false;
                seat.BookingModelId = -1;
            }
            var saloons = _saloonService.GetSaloons();
            foreach (var saloon in saloons)
            {
                saloon.AvailableSeats = saloon.NumberOfSeats;
            }

            _bookingService.Save();

            return RedirectToAction(nameof(ListView));
        }
    }
}
