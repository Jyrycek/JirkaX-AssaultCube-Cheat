namespace Exceptions
{
    public class InvalidJsonExpection : Exception
    {
        public InvalidJsonExpection(string message) : base (message) { }
    }
}