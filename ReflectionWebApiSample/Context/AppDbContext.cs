using Microsoft.EntityFrameworkCore;
using ReflectionWebApiSample.Entities;

namespace ReflectionWebApiSample.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}
