using FluentValidation.Results;

namespace Domain.SeedWork;

public class ResponseObject<TResponse> : IValidatable
{
    public TResponse Data { get; set; }
    public ValidationResult ValidationResult { get; set; } = new();

    public void AddError(string identify, string error)
    {
        ValidationResult.Errors.Add(new ValidationFailure(identify, error));
    }

    private ResponseObject(TResponse data)
    {
        Data = data;
    }

    private ResponseObject(ValidationResult validationResult)
    {
        ValidationResult = validationResult;
    }

    public static ResponseObject<TResponse> Success(TResponse obj)
    {
        return new(obj);
    }

    public static ResponseObject<TResponse> Failure(ValidationResult validationResult)
    {
        return new(validationResult);
    }
}