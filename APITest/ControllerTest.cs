using CSharp.Controllers;
using CSharp.Data.Models;
using CSharp.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace APITest
{
    public class ControllerTest
    {
        OrdersController _controller;
        IOrderService _service;
        
        public ControllerTest()
        {
            _service = new OrderService();
            _controller = new OrdersController(_service);
        }

        [Fact]
        public void GetOrdersTest()
        {
            
            var result = _controller.Get("");           
            var list = result.Result as OkObjectResult;          
            var listOrders = list.Value as List<Order>;
            Assert.Equal(4, listOrders.Count);
        }

        [Fact]
        public void GetOrdersByNameTest()
        {
            var result = _controller.Get("test2");
            var list = result.Result as OkObjectResult;
            var listOrders = list.Value as List<Order>;
            Assert.Equal(2, listOrders.Count);

        }

        [Theory]
        [InlineData(1,5)]
        public void GetOrderByIdTest(int id1, int id2)
        {
            id1 = 1;
            id2 = 5;
            var notFoundResult = _controller.Get(id2);
            var okResult = _controller.Get(id1);
            //Check for not found result
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
            // verify found result
            var item = okResult.Result as OkObjectResult;
            var order = item.Value as Order;
            Assert.Equal(id1, order.Id);
        }

        [Fact]
        public void PostTest()
        {
            var completeOrder = new Order()
            {
                Id = 5,
                CustomerName = "test5",
                
            };

            var createdResponse = _controller.Post(completeOrder);
            Assert.IsType<CreatedAtActionResult>(createdResponse);
            var item = createdResponse as CreatedAtActionResult;
            var createdorder = item.Value as Order;
            Assert.Equal(completeOrder.Id, createdorder.Id);
            Assert.Equal(completeOrder.CustomerName, createdorder.CustomerName);
            
        }

        [Theory]
        [InlineData(1,5)]
        public void CancelOrderTest(int id1, int id2)
        {
            id1 = 1;
            id2 = 5;

            var notFoundResult = _controller.Remove(id2);
            //assert
            Assert.IsType<NotFoundResult>(notFoundResult);
            Assert.Equal(4, _service.GetOrders().Count());

            var okResult = _controller.Remove(id1);
            Assert.IsType<OkResult>(okResult);
            Assert.Equal(3, _service.GetOrders().Count());

        }
    }
}
