using System;
using Xunit;
using Theta.Models.RequestModel;
using Theta.Services;
using FakeItEasy;
using Theta.Controllers;
using Theta.Models.Database;
using System.Collections.Generic;
using FluentAssertions;

namespace Theta.Tests
{
    public class UnitTest1
    {
        private readonly IOrderService _orders = A.Fake<IOrderService>();
        private readonly ICustomerService _customers = A.Fake<ICustomerService>();
        private readonly OrderController _ordertest;
        private readonly CustomerController _customertest;

        public UnitTest1()
        {
            _ordertest = new OrderController(_orders);
            _customertest = new CustomerController(_customers);
        }

        [Fact]
        public void GetAllOrders_Called_ReturnsOrders()
        {
            // Arrange
            var serviceResponse = new List<Order>
            {
                new Order(),
                new Order()
            };

            A.CallTo(() => _orders.GetAllOrders())
                .Returns(serviceResponse);

            // Act
            var result = _ordertest.Get();

            // Assert
            result.Should().HaveCount(2);
        }

        [Fact]
        public void GetAllCustomers_Called_ReturnsCustomers()
        {
            var serviceResponse = new List<Customer>
            {
                new Customer(),
                new Customer()
            };

            A.CallTo(() => _customers.GetAll())
                .Returns(serviceResponse);

            var result = _customertest.GetAll();

            result.Should().HaveCount(2);
        }
    }
}
