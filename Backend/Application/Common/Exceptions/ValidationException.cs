using FluentValidation.Results;

namespace Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException() : base("") 
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
        {
            Errors = failures
                .GroupBy(e => e.PropertyName.ToLower(), e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }
    }
}
