using System.Collections.Generic;
using Theta.Models.Database;

namespace Theta.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
    }
}