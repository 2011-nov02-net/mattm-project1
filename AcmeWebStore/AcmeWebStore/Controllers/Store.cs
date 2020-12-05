using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Repositories;
using Library.Interfaces;
using Library.Model;


namespace AcmeWebStore.Controllers
{
    public class Store : Controller
    {
        public ILocationRepository Repo { get; }

        public Store(ILocationRepository repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));
        public IActionResult Index()
        {
            ViewBag.numStores = Repo.CountLocations();
            ViewBag.sales = 10223213;
            //ViewBag.sales = 1000000 + 
            return View();
        }

        public IActionResult NewUser()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult Locations()
        {
            IEnumerable<Location> locations = Repo.getLocations().ToList();
            
                ViewData["Locations"] = locations;
          
            return View();
        }
       
    }
}
