using DataLibrary.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebBerrasBio.Controllers;

/// <summary>
/// ActiveMovieController - Denna hanterar lista av alla aktuella visningar som finns för bookning.
/// </summary>
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
