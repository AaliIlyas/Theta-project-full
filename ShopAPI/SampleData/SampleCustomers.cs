using System;
using System.Collections.Generic;
using System.Linq;
using Theta.Models.Database;

namespace Theta.Data
{
    public class SampleCustomers
    {
        public static IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    FirstName = "Bob",
                    LastName = "Smith"
                },
                new Customer
                {
                    FirstName = "Jane",
                    LastName = "Doe"
                },
                new Customer
                {
                    FirstName = "Jack",
                    LastName = "Black"
                }
            };
         }
    }
}