using ProductManagement.Core.Entities;

namespace ProductManagement.Core.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> ListAsync(CancellationToken ct);
    Task<Product?> GetByIdAsync(string id, CancellationToken ct);
    Task<Product> AddAsync(Product product, CancellationToken ct);
    Task<bool> UpdateAsync(Product product, CancellationToken ct);
    Task<bool> DeleteAsync(string id, CancellationToken ct);
}
