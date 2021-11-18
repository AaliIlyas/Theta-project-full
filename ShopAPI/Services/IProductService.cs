using System.Collections.Generic;
using Theta.Models.Database;

namespace Theta.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
    }
}