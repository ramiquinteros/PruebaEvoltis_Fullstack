namespace Application.Common.Exceptions
{
    public class ForbiddenAccessException : Exception
    {
        public ForbiddenAccessException() : base() { }

        public ForbiddenAccessException(string name) : base(name) { }
    }
}
