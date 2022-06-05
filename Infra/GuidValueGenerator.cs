using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infra
{
    public class GuidValueGenerator : ValueGenerator<string>
    {
        public GuidValueGenerator() { }

        public override bool GeneratesTemporaryValues => false;

        public override string Next(EntityEntry entry)
        {
            return Guid.NewGuid().ToString();
        }
    }
}