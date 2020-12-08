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
            TempData.Keep();
            return View();
        }

        public IActionResult CreateCustomer()
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
        public IActionResult CreateOrder(int id, string? message)
        {
            int locChoice = id;
            if (locChoice != 0)
            {
                Library.Model.Location location = LocRepo.GetLocationByIdWithInventory(locChoice);
                TempData.Peek("name");
                TempData["StoreChoice"] = location.Id;
                ViewData["Location"] = location;
                var viewModel = new ViewModels.NewOrderViewModel();
                foreach(var item in location.inventory)
                {
                    viewModel.orderContents.Add(item.Key.Id, 0);
                }
                TempData.Keep();
                if(message != null)
                {
                    viewModel.Message = message;
                }
                return View(viewModel);
            }
            else
            {
                TempData.Keep();
               return RedirectToAction("LocationSelect");
            }
        }
        public IActionResult LocationSelect()
        {
            IEnumerable<Location> locations = LocRepo.GetLocations().ToList();

            ViewData["Locations"] = locations;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewOrder(AcmeWebStore.ViewModels.NewOrderViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var order = new Library.Model.Order();

       

                    string[] customerNameArray = new string[2];
                    string name = TempData["name"] as string;
                    customerNameArray = name.Split(" ");
                    Customer loggedCustomer = new Customer();
                    loggedCustomer.firstName = customerNameArray[0];
                    loggedCustomer.lastName = customerNameArray[1];
                    order.CustomerId = CustRepo.GetCustomerByName(loggedCustomer).Id;
                    order.LocationId = Int32.Parse(TempData["StoreChoice"].ToString());
                    foreach(KeyValuePair<int, int> entry in viewModel.orderContents)
                    {
                        if(entry.Value != 0)
                        {
                            order.OrderContents.Add(ProdRepo.GetProductById(entry.Key), entry.Value);
                        }
                        
                    }
                    
                    bool success = OrdRepo.AddOrder(order);
                    if(success != true)
                    {
                        return RedirectToAction("CreateOrder", new { id = order.LocationId, message = "Quantity requested too large" });
                    }
                    OrdRepo.Save();
                   

                   

                    //return RedirectToAction(nameof(Index));
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Logout()
        {
            TempData.Remove("name");
            TempData.Remove("StoreChoice");
            return RedirectToAction("Index");

        }


    }
}
