using System;
using System.Collections.Generic;
using System.Linq;
using Theta.Models.Database;

namespace Theta.Data
{
    public class SampleProducts
    {
        public static IEnumerable<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Name = "Socks",
                    Price = 1.99
                },
                new Product
                {
                    Name = "T-shirt",
                    Price = 4.99
                },
                new Product
                {
                    Name = "Jeans",
                    Price = 10
                }
            };
         }
    }
}