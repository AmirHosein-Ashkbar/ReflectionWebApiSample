using ReflectionWebApiSample.Context;
using ReflectionWebApiSample.Entities;

namespace ReflectionWebApiSample.Data;

public static class SeedData
{
    public static void Seed(AppDbContext context)
    {
        context.Database.EnsureCreated();

        if (!context.Products.Any())
        {
            context.Products.AddRange(
                new Product { Id = 1, Name = "Laptop", Price = 1500, Description = "Gaming Laptop", IsAvailable = true },
                new Product { Id = 2, Name = "Smartphone", Price = 800, Description = "Latest model", IsAvailable = true },
                new Product { Id = 3, Name = "item3", Price = 800, Description = "Latest model", IsAvailable = false },
                new Product { Id = 4, Name = "item4", Price = 800, Description = "Latest model", IsAvailable = false },
                new Product { Id = 5, Name = "SmartPhone", Price = 800, Description = "Latest model", IsAvailable = true },
                new Product { Id = 6, Name = "Laptop", Price = 800, Description = "Latest model", IsAvailable = false }
            );

            context.SaveChanges();
        }
    }
}