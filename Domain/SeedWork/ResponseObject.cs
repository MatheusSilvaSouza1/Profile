using FluentValidation.Results;

namespace Domain.SeedWork;

public class ResponseObject<TResponse>
{
    public TResponse Data { get; set; }
    public ValidationResult ValidationResult { get; set; }
}
