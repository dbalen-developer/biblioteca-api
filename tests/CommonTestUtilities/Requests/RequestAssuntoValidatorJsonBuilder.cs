using Biblioteca.Communication.Requests;
using Bogus;

namespace CommonTestUtilities.Requests
{
    public class RequestAssuntoValidatorJsonBuilder
    {
        public static AssuntoRequest Build(int assuntoLength = 20)
        {
            return new Faker<AssuntoRequest>()
                 .RuleFor(assunto => assunto.Descricao, (f) => f.Random.String2(assuntoLength));
        }
    }
}
