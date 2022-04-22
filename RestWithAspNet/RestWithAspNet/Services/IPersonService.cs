using RestWithAspNet.Model;

namespace RestWithAspNet.Services
{
    public interface IPersonService
    {
        Client Create(Client person);
        Client FindByID(long id);
        List<Client> FindAll();
        Client Update(Client person);
        void Delete(long id);
    }
}
