namespace Exceptions
{
    public class EmptyJsonExpection : Exception
    {
        public EmptyJsonExpection(string? message) : base(message) { }
    }
}
