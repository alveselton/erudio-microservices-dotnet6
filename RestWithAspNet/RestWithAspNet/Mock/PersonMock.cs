using Bogus;
using Bogus.DataSets;
using RestWithAspNet.Model;
using static Bogus.DataSets.Name;

namespace RestWithAspNet.Mock
{
    public class PersonMock
    {

        public Client Get()
        {
            var person = new Faker<Client>("pt_BR")
            .RuleFor(x => x.FirstName, f => f.Name.FirstName(Gender.Female))
            .RuleFor(x => x.LastName, f => f.Name.LastName(Gender.Female))
            .RuleFor(x => x.Address, f => f.Address.StreetAddress())
            .RuleFor(x => x.Gender, f => f.PickRandom(new string[] { "Masculino", "Feminino" }));

            return person;
        }
    }
}
