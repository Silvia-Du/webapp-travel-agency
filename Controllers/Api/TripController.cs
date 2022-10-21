using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        readonly AgencyContext _ctx = new();

        [HttpGet]
        public IActionResult Get(string? title)
        {

            List<Trip> trips;

            if (title is null)
            {
                trips = _ctx.Trips?.Include("Category").Include("AgeRange").Include("Destination").ToList()!;
            }
            else
            {

                trips = _ctx.Trips?
                    .Where(p => p.Title.ToLower().Contains(title.ToLower()))
                    .Include("AgeRange")
                    .Include("Category")
                    .Include("Destination")
                    .ToList()!;
            }

            return Ok(trips);

        }


        [HttpGet("{id}")]
        public IActionResult Show(int id)
        {
            //cercare la pizza e passarla alla vista
            Trip trip = _ctx.Trips?.Include("Category").Include("AgeRange").Include("Destination").FirstOrDefault(p => p.Id == id)!;

            if (trip is null)
            {
                return NotFound(new { response = "Non è stata trovata nessuna corrispondenza" });
            }

            return Ok(trip);
        }

        [HttpPost]
        public IActionResult Send([FromBody] Message message)
        {
            _ctx.Messages?.Add(message);
            _ctx.SaveChanges();
            return Ok(new { response = "Messaggio inviato correttamente" });
        }
    }
}
