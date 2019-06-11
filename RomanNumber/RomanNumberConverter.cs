namespace RomanNumber
{
    using System.Collections.Generic;
    using System.Linq;

    public static class RomanNumberConverter
    {
        private static readonly Dictionary<char, int> NumericValues = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },
            
            { 'P', 4 },
            { 'Q', 9 },
            { 'R', 40 },
            { 'S', 90 },
            { 'T', 400 },
            { 'U', 900 }
        };

        private static readonly List<char> RomanSymbols = new List<char>
        {
            'I',
            'V',
            'X',
            'L',
            'C',
            'D',
            'M'
        };
        
        public static int Convert(string romanNumber)
        {
            if (HasInvalidSymbols(romanNumber))
            {
                throw new InvalidRomanSymbolException(GetInvalidSymbols(romanNumber));
            }

            var convertibleRomanNumber = BuildConvertibleRomanNumber(romanNumber);

            return convertibleRomanNumber.Sum(symbol => NumericValues[symbol]);
        }

        private static bool HasInvalidSymbols(string romanNumber)
        {
            return romanNumber.Any(symbol => !RomanSymbols.Contains(symbol));
        }

        private static string BuildConvertibleRomanNumber(string romanNumber)
        {
            return romanNumber
                .Replace("IV", "P")
                .Replace("IX", "Q")
                .Replace("XL", "R")
                .Replace("XC", "S")
                .Replace("CD", "T")
                .Replace("CM", "U");
        }

        private static IReadOnlyList<char> GetInvalidSymbols(string romanNumber)
        {
            var invalidSymbols = new List<char>();
            
            foreach (var symbol in romanNumber)
            {
                if (!RomanSymbols.Contains(symbol))
                {
                    invalidSymbols.Add(symbol);
                }
            }

            return invalidSymbols;
        }
    }
}