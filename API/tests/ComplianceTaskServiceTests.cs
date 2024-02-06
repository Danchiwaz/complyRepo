using Xunit;
using Moq;
using API.Models;
using API.Enums;
using API.Interfaces;
using System.Collections.Generic;

namespace APITests
{
    public class ItemServiceServiceTests
    {
        private readonly Mock<ItemService> _mockService;

        public ItemServiceServiceTests()
        {
            _mockService = new Mock<ItemService>();
        }

        [Fact]
        public void GetAllTasks_ReturnsCorrectTasks()
        {
            // Arrange
            _mockService.Setup(service => service.GetAllTasks())
                .Returns(new List<ItemService>());

            // Act
            var tasks = _mockService.Object.GetAllTasks();

            // Assert
            Assert.IsType<List<ItemService>>(tasks);
        }

        [Fact]
        public void AddTask_AddsNewTaskCorrectly()
        {
            // Arrange
            var task = new ItemService { Description = "Test", Category = Category.DataSecurity, Priority = Priority.High, Status = Status.NotStarted };
            _mockService.Setup(service => service.AddTask(It.IsAny<ItemService>()))
                .Returns(task);

            // Act
            var addedTask = _mockService.Object.AddTask(task);

            // Assert
            _mockService.Verify(service => service.AddTask(It.IsAny<ItemService>()), Times.Once());
        }
    }
}
