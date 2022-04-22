using Bogus;
using Bogus.DataSets;
using RestWithAspNet.Model;
using static Bogus.DataSets.Name;

namespace RestWithAspNet.Mock
{
    public class ProductMock
    {

        public Product Get()
        {
            var product = new Faker<Product>("pt_BR")
            .RuleFor(x => x.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Price, p => Convert.ToDecimal(p.Commerce.Price(100, 1000, 2, "")))
            .RuleFor(x => x.Description, f => f.Commerce.ProductAdjective())
            .RuleFor(x => x.CategoryName, f => f.Commerce.Categories(2)[0].ToString());
            return product;
        }
    }
}
