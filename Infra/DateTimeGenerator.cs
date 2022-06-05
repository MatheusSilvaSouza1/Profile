using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infra
{
    public class DateTimeGenerator : ValueGenerator<DateTime>
    {
        public DateTimeGenerator() { }

        public override bool GeneratesTemporaryValues => false;

        public override DateTime Next(EntityEntry entry)
        {
            if (entry is null)
            {
                throw new ArgumentNullException(nameof(entry));
            }

            return DateTime.UtcNow;
        }
    }
}