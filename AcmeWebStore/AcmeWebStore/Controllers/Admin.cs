using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Interfaces;
using Library.Model;

namespace AcmeWebStore.Controllers
{
    public class Admin : Controller
    {
        public ILocationRepository Repo { get; }

        public Admin(ILocationRepository repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Locations()
        {
            IEnumerable<Location> locations = Repo.GetLocations().ToList();

            ViewData["Locations"] = locations;

            return View();
        }

        public IActionResult LocationInventory(int id)
        {
            Location thisLocation = Repo.GetLocationById(id);
            ViewData["Location"] = thisLocation;
            return View();
        }
    }
}
