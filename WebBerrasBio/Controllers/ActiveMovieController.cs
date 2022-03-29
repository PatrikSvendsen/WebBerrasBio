using DataLibrary.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebBerrasBio.Controllers;

public class ActiveMovieController : Controller
{
    private readonly IActiveMovieService _activeMovieServce;

    public ActiveMovieController(IActiveMovieService activeMovieService)
    {
        _activeMovieServce = activeMovieService;
    }

    public ActionResult ListView()
    {
        var activeMovies = _activeMovieServce.GetDetailedActiveMovieList();
        return View(activeMovies);
    }
}
