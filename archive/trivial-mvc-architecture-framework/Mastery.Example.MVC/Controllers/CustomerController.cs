using Mastery.Example.BLL.Common.Interfaces;
using Mastery.Example.BLL.Common.Models.Customer;
using System.Web.Mvc;

namespace Mastery.Example.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService service;

        public CustomerController(ICustomerService service) 
            => this.service = service;

        public ActionResult AllCustomers() 
            => View(service.GetCustomers());

        public ActionResult CreateCustomer() 
            => View();

        [HttpPost]
        public ActionResult CreateCustomer(CustomerRequestModel customer)
            => View(service.CreateCustomers(customer));
    }
}