using System;
using Xunit;

namespace DeveloperSample.Algorithms
{
    public class AlgorithmTest
    {
        //[Fact(Skip="Not implemented")]
        [Fact]
        public void CanGetFactorial()
        {
            Assert.Equal(24, Algorithms.GetFactorial(4));
        }

        [Fact]
        public void CanGetFactorialOfZero()
        {
            Assert.Equal(1, Algorithms.GetFactorial(0));
        }

        [Fact]
        public void CanGetFactorialOfOne()
        {
            Assert.Equal(1, Algorithms.GetFactorial(1));
        }

        [Fact]
        public void ThrowsOnNegativeInput()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Algorithms.GetFactorial(-5));
        }


        //[Fact(Skip="Not implemented")]
        [Fact]
        public void CanFormatSeparators()
        {
            Assert.Equal("a, b and c", Algorithms.FormatSeparators("a", "b", "c"));
        }

        [Fact]
        public void FormatSeparators_ReturnsEmptyString_WhenNoItemsProvided()
        {
            Assert.Equal(string.Empty, Algorithms.FormatSeparators());
        }

        [Fact]
        public void FormatSeparators_ReturnsItem_WhenOnlyOneItemProvided()
        {
            Assert.Equal("a", Algorithms.FormatSeparators("a"));
        }

        [Fact]
        public void FormatSeparators_ReturnsItemsWithAnd_WhenTwoItemsProvided()
        {
            Assert.Equal("a and b", Algorithms.FormatSeparators("a", "b"));
        }

    }
}