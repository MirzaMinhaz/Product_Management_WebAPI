using Mapster;
using ProductManagement.Core.Entities;
using ProductManagement.Application.DTOs;

namespace ProductManagement.Application.Mapping;

public static class MapsterConfig
{
    public static void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Product, ProductListItemDto>();
        config.NewConfig<ProductCreateDto, Product>()
              .Map(dest => dest.Id, _ => string.Empty)
              .Map(dest => dest.CreatedAtUtc, _ => DateTime.UtcNow);
        config.NewConfig<ProductUpdateDto, Product>()
              .Map(dest => dest.UpdatedAtUtc, _ => DateTime.UtcNow);

        config.NewConfig<Category, CategoryListItemDto>();
        config.NewConfig<CategoryCreateDto, Category>()
              .Map(dest => dest.Id, _ => string.Empty)
              .Map(dest => dest.CreatedAtUtc, _ => DateTime.UtcNow);
        config.NewConfig<CategoryUpdateDto, Category>()
              .Map(dest => dest.UpdatedAtUtc, _ => DateTime.UtcNow);
    }
}
