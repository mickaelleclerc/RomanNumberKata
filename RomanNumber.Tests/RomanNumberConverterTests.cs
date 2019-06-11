namespace RomanNumber.Tests
{
    using System;
    using FluentAssertions;
    using Xunit;

    public class RomanNumberConverterTests
    {
        [Theory]
        [InlineData("I", 1)]
        [InlineData("V", 5)]
        [InlineData("X", 10)]
        [InlineData("L", 50)]
        [InlineData("C", 100)]
        [InlineData("D", 500)]
        [InlineData("M", 1000)]
        public void Given_ValidRomanSymbol_Then_ConvertSymbolToDigit(string romanSymbol, int expected)
        {
            // Act
            int numeralDigit = RomanNumberConverter.Convert(romanSymbol);

            // Assert
            numeralDigit.Should().Be(expected);
        }

        [Fact]
        public void Given_InvalidRomanSymbol_Then_ThrowInvalidRomanSymbolException()
        {
            // Arrange
            const string invalidSymbol = "R";
            
            // Act
            Action action = () => RomanNumberConverter.Convert(invalidSymbol);

            // Asset
            action.Should()
                .Throw<InvalidRomanSymbolException>()
                .WithMessage("R is an invalid roman symbol");
        }
        
        [Fact]
        public void Given_MultipleInvalidRomanSymbols_Then_ThrowInvalidRomanSymbolException()
        {
            // Arrange
            const string invalidSymbols = "RP";
            
            // Act
            Action action = () => RomanNumberConverter.Convert(invalidSymbols);

            // Asset
            action.Should()
                .Throw<InvalidRomanSymbolException>()
                .WithMessage("R, P are invalid roman symbols");
        }

        [Theory]
        [InlineData("IV", 4)]
        [InlineData("IX", 9)]
        [InlineData("XL", 40)]
        [InlineData("XC", 90)]
        [InlineData("CD", 400)]
        [InlineData("CM", 900)]
        public void Given_RomanNumberWithSubtractiveSymbol_Then_ConvertToNumeral(string romanNumber, int expected)
        {
            // Act
            int numeralNumber = RomanNumberConverter.Convert(romanNumber);

            // Asset
            numeralNumber.Should().Be(expected);
        }
        
        [Theory]
        [InlineData("MDCCLXXVI", 1776)]
        [InlineData("MCMLIV", 1954)]
        [InlineData("MCMXC", 1990)]
        [InlineData("MMXIV", 2014)]
        [InlineData("MMXIX", 2019)]
        public void Given_RomanNumber_Then_ConvertToNumeralNumber(string romanNumber, int expected)
        {
            // Act
            int numeralNumber = RomanNumberConverter.Convert(romanNumber);

            // Asset
            numeralNumber.Should().Be(expected);
        }
    }
}