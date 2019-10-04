using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrdersAPI.Controllers;
using OrdersModel.Model;
using OrdersModel.Repositories;
using Xunit;

namespace OrdersUnitTest
{
    public static class OrderControllerUnitTest
    {
        [Fact]
        public static void TestGetOrders()
        {
            // Arrange
            var dbContext = DbContextMock.GetApplicationDBContext(nameof(TestGetOrders));
            RepositoryWrap repositoryWrap = new RepositoryWrap(dbContext);
            var controller = new OrderController(repositoryWrap);

            // Act
            var response =  controller.GetOrders() as ObjectResult;
            var value = response.Value as IQueryable<Order>;

            dbContext.Dispose();

            // Assert
            Assert.NotEmpty(value);
        }
        [Fact]
        public static void TestGetOrder()
        {
            // Arrange
            var dbContext = DbContextMock.GetApplicationDBContext(nameof(TestGetOrders));
            RepositoryWrap repositoryWrap = new RepositoryWrap(dbContext);
            var controller = new OrderController(repositoryWrap);
            var orderID = 1;
            // Act
            var response = controller.GetOrderById(orderID) as ObjectResult;
            var value = response.Value as Order;

            dbContext.Dispose();

            // Assert
            Assert.NotNull(value);
        }
      
    }
}
