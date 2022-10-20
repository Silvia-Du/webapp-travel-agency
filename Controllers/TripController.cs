using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    public class TripController : Controller
    {
        readonly AgencyContext _ctx = new();

        public IActionResult Index()
        {
            List<Trip> trips = _ctx.Trips?.Include("Category").Include("AgeRange").Include("Destination").ToList()!;
            return View(trips);
        }

        public IActionResult Show(int id)
        {

            Trip? trip = _ctx.Trips?.Include("Category").Include("AgeRange").Include("Destination").FirstOrDefault(x => x.Id == id);
            return trip is null ? NotFound("Non è stata trovata nessuna corrispondenza") : View(trip);

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

        public IActionResult Update(int id)
        {

            Trip? trip = _ctx.Trips?.Include("Category").Include("AgeRange").Include("Destination").FirstOrDefault(x => x.Id == id);

            if (trip is null)
            {
                return NotFound("Non è stata trovata nessuna corrispondenza");
            }

            Utility utilityClass = new();
            utilityClass.Trip = trip;
            utilityClass.Categories = _ctx.Categories?.ToList()!;
            utilityClass.Destinations = _ctx.Destinations?.OrderBy(x => x.Id).ToList()!;
            utilityClass.Ranges = _ctx.AgeRanges?.OrderBy(x => x.Id).ToList()!;

            return View(utilityClass);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Utility utility)
        {

            utility.Trip.Id = id;

            if (!ModelState.IsValid)
            {
                utility.Categories = _ctx.Categories?.ToList()!;
                utility.Destinations = _ctx.Destinations?.OrderBy(x => x.Id).ToList()!;
                utility.Ranges = _ctx.AgeRanges?.OrderBy(x => x.Id).ToList()!;
                return View(utility);
            }

            Trip trip = _ctx.Trips?
                .Include("Category").Include("AgeRange").Include("Destination")
                .FirstOrDefault(x => x.Id == id)!;

            trip.Title = utility.Trip.Title;
            trip.Price = utility.Trip.Price;
            trip.StartDate = utility.Trip.StartDate;
            trip.EndDate = utility.Trip.EndDate;
            trip.DaysNum = utility.Trip.DaysNum;
            trip.Image = utility.Trip.Image;
            trip.CategoryId = utility.Trip.CategoryId;
            trip.DestinationId = utility.Trip.DestinationId;
            trip.AgeRangeId = utility.Trip.AgeRangeId;
            trip.Description = utility.Trip.Description;


            _ctx.Trips?.Update(trip);
            _ctx.SaveChanges();

            return View("Show", trip);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {

            Trip? trip = _ctx.Trips?.FirstOrDefault(x => x.Id == id);

            if (trip is null)
            {
                return NotFound("Non è stata trovata nessuna corrispondenza");
            }
            else
            {
                _ctx.Trips?.Remove(trip);
                _ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

        }
    }
}