using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Theta.Models.Database;
using Theta.Models.RequestModel;
using Theta.Services;

namespace Theta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customers;

        public CustomerController(ICustomerService customerService)
        {
            _customers = customerService;
        }

        [HttpGet]
        public IEnumerable<Customer> GetAll()
        {
            return _customers.GetAll();
        }
    }
}
