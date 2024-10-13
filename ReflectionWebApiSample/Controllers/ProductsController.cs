using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReflectionWebApiSample.Entities;
using ReflectionWebApiSample.Helpers;
using System.Reflection;

namespace ReflectionWebApiSample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 1500, Description = "Gaming Laptop", IsAvailable= true },
        new Product { Id = 2, Name = "Smartphone", Price = 800, Description = "Latest model", IsAvailable= true  },
        new Product { Id = 3, Name = "item3", Price = 800, Description = "Latest model" , IsAvailable = false},
        new Product { Id = 4, Name = "item4", Price = 800, Description = "Latest model" , IsAvailable = false},
        new Product { Id = 5, Name = "item5", Price = 800, Description = "Latest model" , IsAvailable = true},
        new Product { Id = 6, Name = "Laptop", Price = 800, Description = "Latest model" , IsAvailable = false},
    };

    [HttpGet("get/{id}")]
    public IActionResult Get(int id, [FromQuery] string fields)
    {
        var product = _products.Find(x => x.Id == id);
        if (product == null)
            return NotFound();

        var result = ReflectionHelper.Project(product, fields);
        return Ok(result);
    }


    [HttpGet("getall")]
    public IActionResult GetAll([FromQuery] string? fields, string? filters)
    {
        var results = ReflectionHelper.Filter(_products, filters);
        var projectedResults = results.Select(r => ReflectionHelper.Project(r, fields));

        return Ok(projectedResults);
    }
}