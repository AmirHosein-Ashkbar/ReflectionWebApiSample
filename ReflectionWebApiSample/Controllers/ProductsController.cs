using Microsoft.AspNetCore.Mvc;
using ReflectionWebApiSample.Context;
using ReflectionWebApiSample.Entities;
using ReflectionWebApiSample.Helpers;

namespace ReflectionWebApiSample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> Get(int id, [FromQuery] string fields)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
            return NotFound();

        var result = ReflectionHelper.Project(product, fields);
        return Ok(result);
    }


    [HttpGet("getall")]
    public IActionResult GetAll([FromQuery] string? fields, string? filters)
    {
        var results = ReflectionHelper.Filter(_context.Products.ToList(), filters);
        var projectedResults = results.Select(r => ReflectionHelper.Project(r, fields));

        return Ok(projectedResults);
    }
}