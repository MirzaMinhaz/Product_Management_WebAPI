using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.DTOs;

public sealed class CategoryListItemDto
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
}

public sealed class CategoryCreateDto
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public sealed class CategoryUpdateDto
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

