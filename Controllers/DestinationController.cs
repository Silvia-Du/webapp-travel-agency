using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    public class DestinationController : Controller
    {
        readonly AgencyContext _ctx = new();

        public IActionResult Index()
        {
            DettailsUtility utility = new();
            utility.Destinations = _ctx.Destinations?.ToList()!;
            return View(utility);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DettailsUtility utilityClass)
        {
            if (!ModelState.IsValid)
            {
                utilityClass.Destinations = _ctx.Destinations?.OrderBy(x => x.Id).ToList()!;

                return View(utilityClass);
            }

            _ctx.Destinations?.Add(utilityClass.Destination);
            _ctx.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {

            Destination? destination = _ctx.Destinations?.FirstOrDefault(x => x.Id == id);

            if (destination is null)
            {
                return NotFound("Non è stata trovata nessuna corrispondenza");
            }

            return View(destination);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Destination formDestination)
        {
            formDestination.Id = id;


            if (!ModelState.IsValid)
            {
                return View(formDestination);
            }

            Destination destination = _ctx.Destinations?
                .FirstOrDefault(x => x.Id == id)!;

            destination.Name = formDestination.Name;
            _ctx.Destinations?.Update(destination);
            _ctx.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {

            Destination? destination = _ctx.Destinations?.FirstOrDefault(x => x.Id == id);

            if (destination is null)
            {
                return NotFound("Non è stata trovata nessuna corrispondenza");
            }
            else
            {
                _ctx.Destinations?.Remove(destination);
                _ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

        }
    }
}