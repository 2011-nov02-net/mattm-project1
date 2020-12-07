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
        public ILocationRepository LocRepo { get; }
        public ICustomerRepository CustRepo { get; }
        public IProductRepository ProdRepo { get; }
        public IOrderRepository OrdRepo { get; }

        public Store(ILocationRepository locrepo, ICustomerRepository custrepo, IOrderRepository ordrepo, IProductRepository prodrepo)
        {
            LocRepo = locrepo ?? throw new ArgumentNullException(nameof(locrepo));
            CustRepo = custrepo ?? throw new ArgumentNullException(nameof(custrepo));
            ProdRepo = prodrepo ?? throw new ArgumentNullException(nameof(prodrepo));
            OrdRepo = ordrepo ?? throw new ArgumentNullException(nameof(ordrepo));

        }
           
 
           
        public IActionResult Index()
        {
            ViewBag.numStores = LocRepo.CountLocations();
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(ViewModels.CustomerViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var customer = new Library.Model.Customer();
                    customer.firstName = viewModel.firstName;
                    customer.lastName = viewModel.lastName;
                    var loggedCustomer = new Library.Model.Customer();
                    loggedCustomer = CustRepo.GetCustomerByName(customer);
                    string loggedName = $"{loggedCustomer.firstName} {loggedCustomer.lastName}";

                    TempData["name"] = loggedName;
                    


                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }

        }

        //public IActionResult newOrder()
        //{
        //    return View();
        //}
        //public IActionResult CreateOrder()
        //{
        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustomer(ViewModels.CustomerViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var customer = new Library.Model.Customer();
                    customer.firstName = viewModel.firstName;
                    customer.lastName = viewModel.lastName;
                    customer.favoriteStore = 0;

                    CustRepo.AddCustomer(customer);
                    CustRepo.Save();

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

    }
}
