using MediatR;
using ProductManagement.Application.DTOs;

namespace ProductManagement.Application.Products.Queries;

public sealed record ListProductsQuery() : IRequest<IEnumerable<ProductListItemDto>>;
