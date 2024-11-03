namespace Biblioteca.Communication.Responses
{
    public class ErrorResponse
    {
        public IEnumerable<string> Errors { get; set; }

        public ErrorResponse(IEnumerable<string> errors) => Errors = errors;

        public ErrorResponse(string error)
        {
            Errors = [error];
        }
    }
}
