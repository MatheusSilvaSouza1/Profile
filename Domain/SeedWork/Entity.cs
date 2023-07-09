using FluentValidation.Results;

namespace Domain.SeedWork
{
    public abstract class Entity : IValidatable
    {
        private string _id;

        public virtual string Id
        {
            get
            {
                return _id;
            }
            protected set => _id = value;
        }

        public ValidationResult ValidationResult { get; set; }

        public bool IsTransient()
        {
            return Id == default;
        }

        public override bool Equals(object obj)
        {
            if (obj is null or not Entity)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            Entity item = (Entity)obj;

            if (item.IsTransient() || IsTransient())
            {
                return false;
            }
            else
            {
                return item.Id == Id;
            }
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode() * 17 + Id.GetHashCode();
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
            {
                return (Object.Equals(right, null)) ? true : false;
            }
            else
            {
                return left.Equals(right);
            }
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        public abstract bool IsValid();
    }
}