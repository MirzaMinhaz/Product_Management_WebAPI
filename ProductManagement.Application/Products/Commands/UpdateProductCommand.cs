using MediatR;
using ProductManagement.Application.DTOs;

namespace ProductManagement.Application.Products.Commands;

public sealed record UpdateProductCommand(ProductUpdateDto Dto) : IRequest<bool>;
