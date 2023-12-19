using AutoMapper;

namespace Catalog.Application.Mappers;

public static class ProductMapper
{
    private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
    {
        var config = new MapperConfiguration(configuration =>
        {
            configuration.ShouldMapProperty = property => property.GetMethod.IsPublic || property.GetMethod.IsAssembly;
            configuration.AddProfile<ProductMappingProfile>();
        });

        var mapper = config.CreateMapper();

        return mapper;
    });

    public static IMapper Mapper => Lazy.Value;
}
