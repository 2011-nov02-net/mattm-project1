using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeWebStore.Controllers
{
    public class Store : Controller
    {
        public IActionResult Index()
        {
            ViewBag.numStores = 5;
            return View(ViewBag);
        }

        public IActionResult NewUser()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }
       
    }
}
