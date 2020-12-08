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
        public ILocationRepository LocRepo { get; }
        public ICustomerRepository CustRepo { get; }
        public IProductRepository ProdRepo { get; }
        public IOrderRepository OrdRepo { get; }


        public Admin(ILocationRepository repo, ICustomerRepository custrepo, IOrderRepository ordrepo, IProductRepository prodrepo)
        {
            LocRepo = repo ?? throw new ArgumentNullException(nameof(repo));
            CustRepo = custrepo ?? throw new ArgumentNullException(nameof(custrepo));
            ProdRepo = prodrepo ?? throw new ArgumentNullException(nameof(prodrepo));
            OrdRepo = ordrepo ?? throw new ArgumentNullException(nameof(ordrepo));
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Locations()
        {
            IEnumerable<Location> locations = LocRepo.GetLocations().ToList();

            ViewData["Locations"] = locations;

            return View();
        }

        public IActionResult LocationInventory(int id)
        {
            Location thisLocation = LocRepo.GetLocationById(id);
            ViewData["Location"] = thisLocation;
            return View();
        }

        public IActionResult OrderSummaries()
        {
            List<ViewModels.OrderViewModel> viewModel = new List<ViewModels.OrderViewModel>();
            List<Library.Model.Order> libOrder = OrdRepo.GetOrders();
            foreach(Library.Model.Order order in libOrder)
            {
                int counter = 0;
                ViewModels.OrderViewModel view = new ViewModels.OrderViewModel();
                if(counter == 0)
                {
                    view.Id = order.Id;
                    Library.Model.Customer customer = CustRepo.GetCustomerById(order.CustomerId);
                    view.Customer.firstName = customer.firstName;
                    view.Customer.lastName = customer.lastName;
                    view.Customer.Id = customer.Id;
                    Library.Model.Location location = LocRepo.GetLocationById(order.Details[0].LocationId);
                    view.Location.Id = location.Id;
                    view.Location.City = location.City;
                }
                foreach(Library.Model.OrderDetails orderDetails in order.Details)
                {
                    Library.Model.Product product = ProdRepo.GetProductById(orderDetails.ProductId);
                    ViewModels.ProductViewModel productViewModel = new ViewModels.ProductViewModel();
                    productViewModel.Name = product.Name;
                    productViewModel.Price = product.Price;
                    view.OrderContents.Add(productViewModel, orderDetails.Quantity);
                    view.Total = decimal.Round(view.GetTotalPrice(), 2);
                }
                counter++;
                viewModel.Add(view);
            }
            return View(viewModel);
        }

        public IActionResult OrderDetails(int id)
        {
            ViewModels.OrderViewModel view = new ViewModels.OrderViewModel();
            Library.Model.Order libOrder = OrdRepo.GetOrderById(id);
            view.Id = libOrder.Id;
            Library.Model.Customer customer = CustRepo.GetCustomerById(libOrder.CustomerId);
            view.Customer.firstName = customer.firstName;
            view.Customer.lastName = customer.lastName;
            view.Customer.Id = customer.Id;
            Library.Model.Location location = LocRepo.GetLocationById(libOrder.Details[0].LocationId);
            view.Location.Id = location.Id;
            view.Location.City = location.City;
            foreach (Library.Model.OrderDetails orderDetails in libOrder.Details)
            {
                Library.Model.Product product = ProdRepo.GetProductById(orderDetails.ProductId);
                ViewModels.ProductViewModel productViewModel = new ViewModels.ProductViewModel();
                productViewModel.Name = product.Name;
                productViewModel.Price = product.Price;
                view.OrderContents.Add(productViewModel, orderDetails.Quantity);
                view.Total = decimal.Round(view.GetTotalPrice(), 2);
            }

            return View(view);
            }
    }
}
