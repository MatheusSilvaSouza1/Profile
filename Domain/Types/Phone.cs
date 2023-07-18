using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.SeedWork;

namespace Domain.Types
{
    public sealed class Phone : ValueObject
    {
        public string Value { get; set; }

        public static implicit operator Phone(string phone)
            => new(phone);

        public static implicit operator string(Phone phone)
            => phone.Value;

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public override string ToString()
        {
            return Value;
        }

        private Phone(string phone)
        {
            Valid(phone);
            Value = phone;
        }

        private static void Valid(string phone)
        {
            if (phone.Length != 11)
            {
                throw new ArgumentException($"{phone} - Telefone inválido");
            }
        }
    }
}