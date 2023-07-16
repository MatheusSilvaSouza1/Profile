using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.SeedWork;

namespace Domain.Types
{
    public sealed class Cpf : ValueObject
    {
        public string Value { get; }

        private const int MaxNumberCaracteres = 11;

        private Cpf(string cpf)
        {
            Valid(cpf);
            Value = cpf;
        }

        private static void Valid(string cpf)
        {
            if (string.IsNullOrEmpty(cpf) || cpf.Length > MaxNumberCaracteres)
            {
                throw new ArgumentException("Cpf invalido!");
            }
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