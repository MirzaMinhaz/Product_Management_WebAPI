using MediatR;
using MapsterMapper;
using ProductManagement.Application.DTOs;
using ProductManagement.Core.Entities;
using ProductManagement.Core.Interfaces;

namespace ProductManagement.Application.Products.Commands;

public sealed class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _repo;
    private readonly IMapper _mapper;

    public UpdateProductHandler(IProductRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken ct)
    {
        var entity = _mapper.Map<Product>(request.Dto);
        return await _repo.UpdateAsync(entity, ct);
    }
}
