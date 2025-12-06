using MediatR;
using ProductManagement.Application.DTOs;

namespace ProductManagement.Application.Products.Commands;

public sealed record AddProductCommand(ProductCreateDto Dto) : IRequest<ProductListItemDto>;
