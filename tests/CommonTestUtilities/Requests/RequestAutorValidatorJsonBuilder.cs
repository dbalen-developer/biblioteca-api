using Biblioteca.Communication.Requests;
using Bogus;

namespace CommonTestUtilities.Requests
{
    public class RequestAutorValidatorJsonBuilder
    {
        public static AutorRequest Build(int autorLength = 40)
        {
            return new Faker<AutorRequest>()
                 .RuleFor(autor => autor.Nome, (f) => f.Random.String2(autorLength));
        }
    }
}
