using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.DTOs;

public sealed class ProductListItemDto
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string CategoryId { get; set; } = default!;
    public decimal Price { get; set; }
    public int Stock { get; set; }
}

public sealed class ProductCreateDto
{
    public string Name { get; set; } = default!;
    public string CategoryId { get; set; } = default!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}

public sealed class ProductUpdateDto
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string CategoryId { get; set; } = default!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}

