using Xunit;
using HelloWorldApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldApi.Tests
{
    public class HelloWorldControllerTests
    {
        private readonly HelloWorldController _controller;

        public HelloWorldControllerTests()
        {
            _controller = new HelloWorldController();
        }

        [Fact]
        public void Test_HighOrLow_Returns_High_When_Number_Is_Greater_Than_100()
        {
            // Arrange
            int testValue = 150;

            // Act
            var result = _controller.Get(testValue);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            Assert.Equal("high", jsonResult.Value.ToString());
        }

        [Fact]
        public void Test_HighOrLow_Returns_Low_When_Number_Is_Less_Than_100()
        {
            // Arrange
            int testValue = 50;

            // Act
            var result = _controller.Get(testValue);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            Assert.Equal("low", jsonResult.Value.ToString());
        }

    }
}