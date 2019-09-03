using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Bonsai.Validators
{
    public static class AccountValidator
    {
        private static readonly string EMAIL_PATTERN = @"(?:[a-z0-9!#$%&'*+\/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+\/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])";

        public static bool IsNullEmptyOrWhiteSpace(string word)
        {
            return string.IsNullOrWhiteSpace(word);
        }

        public static bool ContainsLetters(string word)
        {
            return word.Any(c => char.IsLetter(c));
        }

        public static bool ContainsLowerLetters(string word)
        {
            return word.Any(c => char.IsLower(c));
        }

        public static bool ContainsUpperLetters(string word)
        {
            return word.Any(c => char.IsUpper(c));
        }

        public static bool ContainsNumbers(string word)
        {
            return word.Any(c => char.IsNumber(c));
        }

        public static bool ContainsSymbols(string word)
        {
            return word.Any(c => char.IsSymbol(c));
        }

        public static bool ContainsBetweenXAndYCharacters(string word, int min, int max)
        {
            return (word.Length >= min && word.Length <= max);
        }

        public static bool HasEmailFormat(string word)
        {
            return Regex.IsMatch(word, EMAIL_PATTERN);
        }


    }
}
