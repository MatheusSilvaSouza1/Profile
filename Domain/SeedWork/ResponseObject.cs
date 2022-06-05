using FluentValidation.Results;

namespace Domain.SeedWork;

public class ResponseObject<TResponse> : IValidatable
{
    public TResponse Data { get; set; }
    public ValidationResult ValidationResult { get; set; }

    public ResponseObject(TResponse data)
    {
        Data = data;
    }

    public ResponseObject(ValidationResult validationResult)
    {
        ValidationResult = validationResult;
    }
}
