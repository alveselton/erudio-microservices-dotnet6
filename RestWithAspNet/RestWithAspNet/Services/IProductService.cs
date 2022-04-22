using RestWithAspNet.Model;

namespace RestWithAspNet.Services
{
    public interface IProductService
    {
        List<Product> FindAll();
    }
}
