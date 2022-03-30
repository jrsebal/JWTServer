﻿using MediatR;
using MediatrValidationExample.Features.Products.Commands;
using MediatrValidationExample.Features.Products.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MediatrValidationExample.Controllers;


[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Consulta los productos
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public Task<List<GetProductsResponse>> GetProducts() => _mediator.Send(new GetProductsQuery());

    /// <summary>
    /// Crea un producto nuevo
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }
}
