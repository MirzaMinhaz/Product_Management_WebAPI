using ProductManagement.Core.Entities;
using ProductManagement.Core.Interfaces;

namespace ProductManagement.Infrastructure.Repositories;

public sealed class InMemoryProductRepository : IProductRepository
{
    private readonly Dictionary<string, Product> _store = new();

    public Task<IEnumerable<Product>> ListAsync(CancellationToken ct)
        => Task.FromResult<IEnumerable<Product>>(_store.Values);

    public Task<Product?> GetByIdAsync(string id, CancellationToken ct)
        => Task.FromResult(_store.TryGetValue(id, out var p) ? p : null);

    public Task<Product> AddAsync(Product product, CancellationToken ct)
    {
        product.Id = product.Id is { Length: > 0 } ? product.Id : Guid.NewGuid().ToString("N");
        product.CreatedAtUtc = DateTime.UtcNow;
        _store[product.Id] = product;
        return Task.FromResult(product);
    }

    public Task<bool> UpdateAsync(Product product, CancellationToken ct)
    {
        if (!_store.ContainsKey(product.Id)) return Task.FromResult(false);
        product.UpdatedAtUtc = DateTime.UtcNow;
        _store[product.Id] = product;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(string id, CancellationToken ct)
        => Task.FromResult(_store.Remove(id));
}
