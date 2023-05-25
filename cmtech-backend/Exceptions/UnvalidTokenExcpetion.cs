namespace cmtech_backend.Exceptions
{
    public class UnvalidTokenExcpetion : Exception
    {
        public UnvalidTokenExcpetion(string message) : base(message) { }

        public UnvalidTokenExcpetion(string message, Exception innerException) : base(message, innerException) { }
    }
}
