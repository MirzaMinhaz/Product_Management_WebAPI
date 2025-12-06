using MediatR;
using ProductManagement.Application.DTOs;

namespace ProductManagement.Application.Products.Queries;

public sealed record GetProductByIdQuery(string Id) : IRequest<ProductListItemDto?>;
