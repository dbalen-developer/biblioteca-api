namespace Biblioteca.Exceptions.ExceptionsBase
{
    public class NotFoundException : CustomBaseException
    {
        public IEnumerable<string> ErrorMessages { get; set; }

        public NotFoundException(IEnumerable<string> errorMessages) : base(string.Empty)
        {
            ErrorMessages = errorMessages;
        }
    }
}
