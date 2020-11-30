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
       
    }
}
