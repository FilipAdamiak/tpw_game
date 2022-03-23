using CalculatorApp;
using Xunit;

namespace CalculatorTests
{
    public class CalculatorTests
    {

        private readonly Calculator _calculator;

        public CalculatorTests()
        {
            _calculator = new Calculator();
        }

        [Fact]
        public void ShouldAddNumbers()
        {
            double actual = _calculator.Add(2, 3);

            Assert.Equal(5, actual);
        }

        [Fact]
        public void ShouldSubstractNumbers()
        {
            double actual = _calculator.Substract(5, 3);

            Assert.Equal(2, actual);
        }

        [Fact]
        public void ShouldMultiplyNumbers()
        {
            double actual = _calculator.Multiply(2, 2);

            Assert.Equal(4, actual);
        }

        [Fact]
        public void ShouldDivideNumbers()
        {
            double actual = _calculator.Divide(4, 2);

            Assert.Equal(2, actual);
        }
    }
}