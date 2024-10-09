using Xunit;
using HelloWorldApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldApi.Tests
{
    public class HelloWorldControllerRegressionTests
    {
        private readonly HelloWorldController _controller;

        public HelloWorldControllerRegressionTests()
        {
            _controller = new HelloWorldController();
        }

        [Theory]
        [InlineData(200, "high")]  // Test with a large positive number
        [InlineData(-1, "low")]     // Test with a negative number
        [InlineData(0, "low")]      // Test with zero
        [InlineData(100, "low")]    // Test with exactly 100
        [InlineData(99, "low")]     // Test with a number just below 100
        [InlineData(101, "high")]   // Test with a number just above 100
        public void Get_ShouldReturnExpectedResult_ForVariousInputs(int input, string expected)
        {
            // Act
            var result = _controller.Get(input) as JsonResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected, result.Value.ToString());
        }

        [Fact]
        public void Get_ShouldReturn_ExpectedResponse_For_Multiple_Consecutive_Calls()
        {
            // Arrange
            int[] testValues = { 50, 150, 100, 99, 101 };

            // Act & Assert
            foreach (var value in testValues)
            {
                var result = _controller.Get(value) as JsonResult;
                Assert.NotNull(result);

                // Expected results
                string expected = value > 100 ? "high" : "low";
                Assert.Equal(expected, result.Value.ToString());
            }
        }
    }
}