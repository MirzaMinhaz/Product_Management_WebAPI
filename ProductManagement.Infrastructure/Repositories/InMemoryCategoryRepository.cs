using ProductManagement.Core.Entities;
using ProductManagement.Core.Interfaces;

namespace ProductManagement.Infrastructure.Repositories;

public sealed class InMemoryCategoryRepository : ICategoryRepository
{
    private readonly Dictionary<string, Category> _store = new();

    public Task<IEnumerable<Category>> ListAsync(CancellationToken ct)
        => Task.FromResult<IEnumerable<Category>>(_store.Values);

    public Task<Category?> GetByIdAsync(string id, CancellationToken ct)
        => Task.FromResult(_store.TryGetValue(id, out var c) ? c : null);

    public Task<Category> AddAsync(Category category, CancellationToken ct)
    {
        category.Id = category.Id is { Length: > 0 } ? category.Id : Guid.NewGuid().ToString("N");
        category.CreatedAtUtc = DateTime.UtcNow;
        _store[category.Id] = category;
        return Task.FromResult(category);
    }

    public Task<bool> UpdateAsync(Category category, CancellationToken ct)
    {
        if (!_store.ContainsKey(category.Id)) return Task.FromResult(false);
        category.UpdatedAtUtc = DateTime.UtcNow;
        _store[category.Id] = category;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(string id, CancellationToken ct)
        => Task.FromResult(_store.Remove(id));
}
