namespace Exceptions.DatabaseExceptions
{
    public class CannotConnectException : Exception
    {
        public CannotConnectException(string message) : base(message) { }
    }
}
