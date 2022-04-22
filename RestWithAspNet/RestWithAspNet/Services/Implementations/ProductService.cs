using RestWithAspNet.Mock;
using RestWithAspNet.Model;

namespace RestWithAspNet.Services.Implementations
{
    public class ProductService : IProductService
    {
        private volatile int count;
        private List<Product> listProduct;

        public ProductService()
        {
            listProduct = FindAllMock();
        }

        public List<Product> FindAll()
        {
            return listProduct;
        }

        private Product MockProduct(int i)
        {
            var product = new ProductMock().Get();

            return new Product
            {
                Id = IncrementAndGet(),
                Name = product.Name,
                Price = product.Price,
                CategoryName = product.CategoryName,
                Description = product.Description
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        private List<Product> FindAllMock()
        {
            List<Product> products = new();

            for (int i = 0; i < 10; i++)
            {
                Product product = MockProduct(i);
                products.Add(product);
            }

            return products;
        }
    }
}
