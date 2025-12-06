using MapsterMapper;
using MediatR;
using ProductManagement.Application.DTOs;
using ProductManagement.Core.Interfaces;

namespace ProductManagement.Application.Products.Queries;

public sealed class ListProductsHandler : IRequestHandler<ListProductsQuery, IEnumerable<ProductListItemDto>>
{
    private readonly IProductRepository _repo;
    private readonly IMapper _mapper;

    public ListProductsHandler(IProductRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductListItemDto>> Handle(ListProductsQuery request, CancellationToken ct)
    {
        var products = await _repo.ListAsync(ct);
        return products.Select(p => _mapper.Map<ProductListItemDto>(p));
    }
}
