using Bogus;

namespace CommonTestUtilities.Entities
{
    public class AutorBuilder
    {
        public static Biblioteca.Domain.Entities.Autor Build()
        {
            return new Faker<Biblioteca.Domain.Entities.Autor>()
                .RuleFor(a => a.CodAu, () => 1)
                .RuleFor(a => a.Nome, (f) => f.Random.String2(40));
        }
    }
}
