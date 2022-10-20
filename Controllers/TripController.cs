using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using System.Diagnostics;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    public class TripController : Controller
    {
        readonly AgencyContext _ctx = new();

        public IActionResult Index()
        {
            List<Trip> trips = _ctx.Trips?.ToList()!;
            return View(trips);
        }

        public IActionResult Create()
        {
            Utility utilityClass = new();
            utilityClass.Categories = _ctx.Categories?.OrderBy(x => x.Id).ToList()!;
            utilityClass.Destinations = _ctx.Destinations?.OrderBy(x => x.Id).ToList()!;
            utilityClass.Ranges = _ctx.AgeRanges?.OrderBy(x => x.Id).ToList()!;


            return View(utilityClass);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Utility utilityClass)
        {
            if (!ModelState.IsValid)
            {
                utilityClass.Categories = _ctx.Categories?.OrderBy(x => x.Id).ToList()!;
                utilityClass.Destinations = _ctx.Destinations?.OrderBy(x => x.Id).ToList()!;
                utilityClass.Ranges = _ctx.AgeRanges?.OrderBy(x => x.Id).ToList()!;

                return View(utilityClass);
            }




            _ctx.Trips?.Add(utilityClass.Trip);
            _ctx.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}