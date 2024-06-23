using AutoMapper;
using CoffeeMachine.Application.DTOs;
using CoffeeMachine.Application.Interfaces;
using CoffeeMachine.Domain.Entities;
using CoffeeMachine.Domain.Enums;
using CoffeeMachineApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace CoffeeMachineApi.Tests
{
    public class BeveragesControllerTest
    {
        private readonly Mock<ILogger<BeveragesController>> _loggerMock;
        private readonly Mock<IBeverageRepository> _beverageServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly BeveragesController _controller;

        public BeveragesControllerTest()
        {
            _loggerMock = new Mock<ILogger<BeveragesController>>();
            _beverageServiceMock = new Mock<IBeverageRepository>();
            _mapperMock = new Mock<IMapper>();
            _controller = new BeveragesController(_loggerMock.Object, _beverageServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public void Get_ReturnsOkResult_WithBeverageDtos()
        {
            // Arrange
            var beverages = new List<Beverage>
                {
                    new Beverage { BeverageId = 1, BeverageType = BeverageType.Espresso },
                    new Beverage { BeverageId = 2, BeverageType = BeverageType.Lait }
                };
            var beverageDtos = new List<BeverageDto>
                {
                    new BeverageDto { BeverageId = 1, Name = "Espresso" },
                    new BeverageDto { BeverageId = 2, Name = "Lait" }
                };

            _beverageServiceMock.Setup(mock => mock.GetBeverages()).Returns(beverages);
            _mapperMock.Setup(mock => mock.Map<IEnumerable<BeverageDto>>(beverages)).Returns(beverageDtos);

            // Act
            var result = _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedBeverageDtos = Assert.IsAssignableFrom<IEnumerable<BeverageDto>>(okResult.Value);
            Assert.Equal(beverageDtos, returnedBeverageDtos);
        }

        [Fact]
        public void Get_ReturnsInternalServerError_WhenExceptionOccurs()
        {
            // Arrange
            var exceptionMessage = "An error occurred while retrieving beverages.";
            _beverageServiceMock.Setup(mock => mock.GetBeverages()).Throws(new Exception(exceptionMessage));

            // Act
            var result = _controller.Get();

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
            Assert.Equal(exceptionMessage, statusCodeResult.Value);
        }

        [Fact]
        public void GetBeverage_ReturnsOkResult_WithBeverageResponse()
        {
            // Arrange
            var beverageId = 1;
            var beverageResponse = new BeverageResponse { BeverageId = beverageId, Name = "Espresso", Price = 0.52m };

            _beverageServiceMock.Setup(mock => mock.GetBeverage(beverageId)).Returns(beverageResponse);

            // Act
            var result = _controller.GetBeverage(beverageId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedBeverageResponse = Assert.IsType<BeverageResponse>(okResult.Value);
            Assert.Equal(beverageResponse, returnedBeverageResponse);
        }

        [Fact]
        public void GetBeverage_ReturnsNotFound_WhenBeverageIsNull()
        {
            // Arrange
            var beverageId = 10;
            BeverageResponse? beverage = null;

            _beverageServiceMock.Setup(mock => mock.GetBeverage(beverageId)).Returns(beverage);

            // Act
            var result = _controller.GetBeverage(beverageId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetBeverage_ReturnsInternalServerError_WhenExceptionOccurs()
        {
            // Arrange
            var beverageId = 1;
            var exceptionMessage = $"An error occurred while retrieving beverage with Id : {beverageId}.";
            _beverageServiceMock.Setup(mock => mock.GetBeverage(beverageId)).Throws(new Exception(exceptionMessage));

            // Act
            var result = _controller.GetBeverage(beverageId);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
            Assert.Equal(exceptionMessage, statusCodeResult.Value);
        }
    }
}