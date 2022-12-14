using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    public class GuestController : Controller
    {

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Show(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}