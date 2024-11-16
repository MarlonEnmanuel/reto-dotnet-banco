namespace Shared.Exceptions
{
    public class ValidationException : Exception
    {
        private string[]? Details { get; }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, params string[] details) : base(message)
        {
            Details = details;
        }
    }
}
