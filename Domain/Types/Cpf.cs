using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Domain.SeedWork;

namespace Domain.Types
{
    public sealed class Cpf : ValueObject
    {
        public string Value { get; }

        private const int MaxNumberCaracteres = 11;
        private static readonly IReadOnlyCollection<string> _invalidCpfs = new List<string>()
        {
            "00000000000",
            "11111111111",
            "22222222222",
            "33333333333",
            "44444444444",
            "55555555555",
            "66666666666",
            "77777777777",
            "88888888888",
            "99999999999",
        };

        private Cpf(string cpf)
        {
            Valid(cpf);
            Value = cpf;
        }

        private static void Valid(string cpf)
        {
            var cleanCaractereInvalid = Regex.Replace(cpf, @"[^0-9]", string.Empty);
            if (_invalidCpfs.Contains(cpf) || string.IsNullOrEmpty(cleanCaractereInvalid) || cleanCaractereInvalid.Length != MaxNumberCaracteres)
            {
                throw new ArgumentException("Cpf invalido!");
            }

            Span<int> numbers = stackalloc int[11];
            for (int i = 0; i < 11; i++)
            {
                numbers[i] = cleanCaractereInvalid[i] - '0';
            }

            var firstCheckDigit = CalculeCheckDigit(numbers[..9], 10);
            var isValidFirstDigit = numbers[9] == firstCheckDigit;
            if (!isValidFirstDigit)
            {
                throw new ArgumentException("Cpf invalido!");
            }

            var secondCheckDigit = CalculeCheckDigit(numbers[..10], 11);
            var isValidSecondDigit = numbers[10] == secondCheckDigit;
            if (!isValidSecondDigit)
            {
                throw new ArgumentException("Cpf invalido!");
            }
        }

        private static int CalculeCheckDigit(Span<int> numbers, int countController)
        {
            var sum = 0;
            foreach (var digit in numbers)
            {
                sum += digit * countController;
                countController--;
            }

            var remainderDivision = sum % 11;
            var calculeCheckDigit = 11 - remainderDivision;

            return calculeCheckDigit >= 10 ? 0 : calculeCheckDigit;
        }

        public static implicit operator Cpf(string cpf)
        {
            return new(cpf);
        }

        public static explicit operator string(Cpf cpf)
        {
            return cpf.Value;
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public override string ToString()
        {
            return Value;
        }

        public string ToStringFormatted()
        {
            return $"{Value[..3]}.{Value.Substring(3, 3)}.{Value.Substring(6, 3)}-{Value[9..]}";
        }
    }
}