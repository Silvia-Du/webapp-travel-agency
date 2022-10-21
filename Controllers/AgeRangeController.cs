using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    [Authorize]
    public class AgeRangeController : Controller
    {
        readonly AgencyContext _ctx = new();
       
        public IActionResult Index()
        {
            DettailsUtility utility = new();
            utility.Ranges = _ctx.AgeRanges?.ToList()!;
            return View(utility);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DettailsUtility utilityClass)
        {
            if (!ModelState.IsValid)
            {
                utilityClass.Ranges = _ctx.AgeRanges?.OrderBy(x => x.Id).ToList()!;

                return View(utilityClass);
            }
            if (utilityClass.Ranges is null)
            {
                return NotFound("Non è stata trovata nessuna corrispondenza");
            }

            _ctx.AgeRanges?.Add(utilityClass.AgeRange);
            _ctx.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {

            AgeRange? range = _ctx.AgeRanges?.FirstOrDefault(x => x.Id == id);

            if (range is null)
            {
                return NotFound("Non è stata trovata nessuna corrispondenza");
            }

            return View(range);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, AgeRange formRange)
        {
            formRange.Id = id;


            if (!ModelState.IsValid)
            {
                return View(formRange);
            }

            AgeRange? range = _ctx.AgeRanges?.FirstOrDefault(x => x.Id == id);

            range.Range = formRange.Range;
            _ctx.AgeRanges?.Update(range);
            _ctx.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {

            AgeRange? range = _ctx.AgeRanges?.FirstOrDefault(x => x.Id == id);

            if (range is null)
            {
                return NotFound("Non è stata trovata nessuna corrispondenza");
            }
            else
            {
                _ctx.AgeRanges?.Remove(range);
                _ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

        }
    }
}