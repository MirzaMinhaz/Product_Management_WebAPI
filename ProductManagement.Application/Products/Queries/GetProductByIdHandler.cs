using MapsterMapper;
using MediatR;
using ProductManagement.Application.DTOs;
using ProductManagement.Core.Interfaces;

namespace ProductManagement.Application.Products.Queries;

public sealed class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductListItemDto?>
{
    private readonly IProductRepository _repo;
    private readonly IMapper _mapper;

    public GetProductByIdHandler(IProductRepository repo, IMapper mapper)
    { _repo = repo; _mapper = mapper; }

    public async Task<ProductListItemDto?> Handle(GetProductByIdQuery request, CancellationToken ct)
    {
        var entity = await _repo.GetByIdAsync(request.Id, ct);
        return entity is null ? null : _mapper.Map<ProductListItemDto>(entity);
    }
}
