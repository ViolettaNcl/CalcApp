using System;
using Xunit;
using CalcApp;

namespace CalcApp.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(3, 2, "+", 5)]
        [InlineData(5, 3, "-", 2)]
        [InlineData(4, 6, "*", 24)]
        [InlineData(10, 2, "/", 5)]
        [InlineData(10, 2, ":", 5)]
        public void Test_Compute_ValidOperations(double a, double b, string sign, double expected)
        {
            // Act
            double result = Calculator.Compute(a, b, sign);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_Compute_DivisionByZero()
        {
            // Act & Assert
            var exception = Assert.Throws<DivideByZeroException>(() => Calculator.Compute(10, 0, "/"));
            Assert.Equal("Division by zero", exception.Message);
        }

        [Fact]
        public void Test_Compute_InvalidOperation()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => Calculator.Compute(10, 2, "%"));
            Assert.Equal("Invalid operation", exception.Message);
        }
    }
}