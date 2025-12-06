using ProductManagement.Core.Entities;

namespace ProductManagement.Core.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> ListAsync(CancellationToken ct);
    Task<Category?> GetByIdAsync(string id, CancellationToken ct);
    Task<Category> AddAsync(Category category, CancellationToken ct);
    Task<bool> UpdateAsync(Category category, CancellationToken ct);
    Task<bool> DeleteAsync(string id, CancellationToken ct);
}
