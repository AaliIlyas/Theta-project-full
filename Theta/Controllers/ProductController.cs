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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _products;

        public ProductController(IProductService productService)
        {
            _products = productService;
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _products.GetAll();
        }
    }
}
