using System.Web.Http;
using Mastery.Example.BLL.Common.Interfaces;
using Mastery.Example.BLL.Common.Models.Customer;

namespace Mastery.Example.WebAPI.Api.v1
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerService service;

        public CustomerController(ICustomerService service) 
            => this.service = service;

        public IHttpActionResult GetCustomers() 
            => Ok(service.GetCustomers());

        [HttpPost]
        public IHttpActionResult CreateCustomers([FromBody]CustomerRequestModel customer) 
            => Ok(service.CreateCustomers(customer));
    }
}
