namespace AutoMarketProject.Application.Common.Exceptions;

public class ValidationAppException : Exception
{
    public ValidationAppException(IReadOnlyDictionary<string, string[]> errors)
        : base("One or more validation errors occurred")
    {
        Errors = errors;
    }

    public IReadOnlyDictionary<string, string[]> Errors { get; }
}