using MediatR;
using ProductManagement.Core.Interfaces;

namespace ProductManagement.Application.Products.Commands;

public sealed class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _repo;
    public DeleteProductHandler(IProductRepository repo) => _repo = repo;

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken ct)
        => await _repo.DeleteAsync(request.Id, ct);
}
