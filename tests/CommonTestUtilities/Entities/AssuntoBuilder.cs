using Bogus;

namespace CommonTestUtilities.Entities
{
    public class AssuntoBuilder
    {
        public static Biblioteca.Domain.Entities.Assunto Build()
        {
            return new Faker<Biblioteca.Domain.Entities.Assunto>()
                .RuleFor(a => a.CodAs, () => 1)
                .RuleFor(a => a.Descricao, (f) => f.Random.String2(20));
        }
    }
}
