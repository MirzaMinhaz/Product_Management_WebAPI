using MediatR;

namespace ProductManagement.Application.Products.Commands;

public sealed record DeleteProductCommand(string Id) : IRequest<bool>;
