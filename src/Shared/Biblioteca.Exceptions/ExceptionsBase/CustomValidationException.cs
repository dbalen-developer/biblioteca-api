namespace Biblioteca.Exceptions.ExceptionsBase
{
    public class CustomValidationException : CustomBaseException
    {
        public IEnumerable<string> ErrorMessages { get; set; }

        public CustomValidationException(IEnumerable<string> errorMessages) : base(string.Empty)
        {
            ErrorMessages = errorMessages.Distinct();
        }
    }
}
