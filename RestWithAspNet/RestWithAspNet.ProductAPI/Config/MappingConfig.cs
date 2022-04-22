using AutoMapper;
using RestWithAspNet.ProductAPI.Data.ValueObjects;
using RestWithAspNet.ProductAPI.Model;

namespace RestWithAspNet.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            });

            return mappingConfig;
        }
    }
}
