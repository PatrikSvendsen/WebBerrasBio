using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebBerrasBio.Models;

namespace WebBerrasBio.Controllers
{
    /// <summary>
    /// Standard HomeController - Den finns kvar ebart för att hantera Error och felhantering. 
    /// </summary>
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}