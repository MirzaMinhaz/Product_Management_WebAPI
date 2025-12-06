using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.DTOs;
using ProductManagement.Application.Products.Commands;
using ProductManagement.Application.Products.Queries;

namespace ProductManagement.Api.Controllers.v1;

[ApiController]
//[Authorize]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/products")]
public sealed class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductListItemDto>>> List(CancellationToken ct)
        => Ok(await _mediator.Send(new ListProductsQuery(), ct));

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductListItemDto>> GetById(string id, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetProductByIdQuery(id), ct);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ProductListItemDto>> Create([FromBody] ProductCreateDto dto, CancellationToken ct)
    {
        var created = await _mediator.Send(new AddProductCommand(dto), ct);
        return CreatedAtAction(nameof(GetById), new { id = created.Id, version = "1.0" }, created);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(string id, [FromBody] ProductUpdateDto dto, CancellationToken ct)
    {
        if (id != dto.Id) return BadRequest(new { message = "Route id and body id mismatch" });
        var success = await _mediator.Send(new UpdateProductCommand(dto), ct);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id, CancellationToken ct)
    {
        var success = await _mediator.Send(new DeleteProductCommand(id), ct);
        return success ? NoContent() : NotFound();
    }
}
