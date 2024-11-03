namespace Biblioteca.Exceptions.ExceptionsBase
{
    public class CustomBaseException : SystemException
    {
        public CustomBaseException(string message) : base(message) { }
    }
}
