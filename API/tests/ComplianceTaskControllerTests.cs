using Xunit;
using Moq;
using API.Controllers;
using API.Models;
using API.Enums;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APITests
{
    public class ItemServiceControllerTests
    {
        private readonly Mock<ItemService> _mockService;
        private readonly ItemServiceController _controller;

        public ItemServiceControllerTests()
        {
            _mockService = new Mock<ItemService>();
            _controller = new ItemServiceController(_mockService.Object);
        }

        [Fact]
        public void GetTasks_ReturnsOkResult()
        {
            var okResult = _controller.GetTasks();
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void AddTask_ReturnsCreatedAtAction()
        {
            var task = new ItemService { Description = "Test", Category = Category.DataSecurity, Priority = Priority.High, Status = Status.NotStarted };

            _mockService.Setup(service => service.AddTask(It.IsAny<ItemService>())).Returns(task);

            var createdResult = _controller.AddTask(task);
            Assert.IsType<CreatedAtActionResult>(createdResult.Result);
        }
    }
}
