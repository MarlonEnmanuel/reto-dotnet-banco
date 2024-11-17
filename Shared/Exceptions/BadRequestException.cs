namespace Shared.Exceptions
{
    public class BadRequestException : Exception
    {
        private string[]? Details { get; }

        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(string message, params string[] details) : base(message)
        {
            Details = details;
        }
    }
}
