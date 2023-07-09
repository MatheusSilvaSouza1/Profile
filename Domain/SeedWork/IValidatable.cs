using FluentValidation.Results;

namespace Domain.SeedWork
{
    public interface IValidatable
    {
        ValidationResult ValidationResult { get; set; }
    }
}