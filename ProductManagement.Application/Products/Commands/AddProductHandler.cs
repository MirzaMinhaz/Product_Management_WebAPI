using MapsterMapper;
using MediatR;
using ProductManagement.Application.DTOs;
using ProductManagement.Core.Entities;
using ProductManagement.Core.Interfaces;

namespace ProductManagement.Application.Products.Commands;

public sealed class AddProductHandler : IRequestHandler<AddProductCommand, ProductListItemDto>
{
    private readonly IProductRepository _repo;
    private readonly IMapper _mapper;

    public AddProductHandler(IProductRepository repo, IMapper mapper)
    {
        _repo = repo; _mapper = mapper;
    }

    public async Task<ProductListItemDto> Handle(AddProductCommand request, CancellationToken ct)
    {
        var entity = _mapper.Map<Product>(request.Dto);
        var created = await _repo.AddAsync(entity, ct);
        return _mapper.Map<ProductListItemDto>(created);
    }
}
