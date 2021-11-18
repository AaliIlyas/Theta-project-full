using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theta.Context;
using Theta.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace Theta.Services
{
    public class ProductService : IProductService
    {
        private readonly RetailContext _context;
        public ProductService(RetailContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Product
                .FromSqlRaw<Product>("SELECT * FROM Product");
        }
    }
}
