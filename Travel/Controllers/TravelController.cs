using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Travel.Data;
using Travel.Entities;
using Travel.Filter;
using Travel.ViewModels;

namespace Travel.Controllers
{
    public class TravelController : Controller
    {
        private readonly DatabaseContext _context;

        public TravelController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<TravelModel> travelModels = _context.Travels.Include(c => c.Country)
                  .Include(c => c.City).ToList();
            ViewBag.Travels = travelModels;
          ViewBag.countryList = _context.Countries.Include(c=>c.Cities).ToList();
          ViewBag.cityList = _context.Countries.Include(c=>c.Cities).ToList();
          return View();
        }
        public IActionResult Create()
        {
            ViewBag.Cities = new SelectList(_context.Cities.ToList(), "Id", "Name");
            ViewBag.Countries = new SelectList(_context.Countries.ToList(), "Id", "Name");
            var countryList = _context.Countries.Include(c => c.Cities).ToList();
            var cityList = _context.Cities.ToList();
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TravelVM model)
        {

            ViewBag.Cities = new SelectList(_context.Cities.ToList(), "Id", "Name");
            ViewBag.Countries = new SelectList(_context.Countries.ToList(), "Id", "Name");
            //List<TravelModel> travels = new List<TravelModel>();

            TravelModel travel = new TravelModel()
            {
                CityId = model.CityId,
                CountryId = model.CountryId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Fund = model.Fund
            };
            _context.Travels.Add(travel);
            _context.SaveChanges();
            return Ok(travel);
        }

        public IActionResult Filter([FromQuery] Filtering filter)
        {
             
            return View();
        }

      
    }
}