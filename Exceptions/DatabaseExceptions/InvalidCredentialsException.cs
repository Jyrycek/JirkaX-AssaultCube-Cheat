namespace Exceptions.DatabaseExceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException(string message) : base (message) { }
    }
}
