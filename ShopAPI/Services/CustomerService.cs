using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theta.Context;
using Theta.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace Theta.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly RetailContext _context;
        public CustomerService(RetailContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customer.FromSqlRaw<Customer>("SELECT * FROM Customer");
        }
    }
}
