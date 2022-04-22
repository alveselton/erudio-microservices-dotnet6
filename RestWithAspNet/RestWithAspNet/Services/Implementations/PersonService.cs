using RestWithAspNet.Mock;
using RestWithAspNet.Model;

namespace RestWithAspNet.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private volatile int count;
        private List<Client> listClient;

        public PersonService()
        {
            listClient = FindAllMock();
        }

        public Client Create(Client person)
        {
            listClient.Add(person);

            return person;
        }

        public void Delete(long id)
        {
            var client = listClient.SingleOrDefault(x=>x.Id == id);
            listClient.Remove(client);
        }

        public List<Client> FindAll()
        {
            return listClient;
        }

        public Client FindByID(long id)
        {
            return listClient.FirstOrDefault(x=> x.Id == id);
        }

        public Client Update(Client person)
        {
            return person;
        }

        private Client MockPerson(int i)
        {
            var person = new PersonMock().Get();

            return new Client
            {
                Id = IncrementAndGet(),
                FirstName = person.FirstName,
                LastName = person.LastName,
                Address = person.Address,
                Gender = person.Gender
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        private List<Client> FindAllMock()
        {
            List<Client> persons = new();

            for (int i = 0; i < 10; i++)
            {
                Client person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
        }
    }
}
