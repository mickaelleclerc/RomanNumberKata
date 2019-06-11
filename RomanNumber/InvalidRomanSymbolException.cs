namespace RomanNumber
{
    using System;
    using System.Collections.Generic;

    public class InvalidRomanSymbolException : Exception
    {
        public InvalidRomanSymbolException(IReadOnlyList<char> invalidSymbols)
        : base(BuildErrorMessage(invalidSymbols))
        {
        }

        private static string BuildErrorMessage(IReadOnlyList<char> invalidSymbols)
        {
            if (invalidSymbols.Count == 1)
            {
                return $"{invalidSymbols[0]} is an invalid roman symbol";
            }
            
            return $"{string.Join(", ", invalidSymbols)} are invalid roman symbols";
        }
    }
}