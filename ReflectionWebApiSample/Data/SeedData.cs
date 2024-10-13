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
                new Product { Name = "Laptop", Price = 1500, Description = "Gaming Laptop", IsAvailable = true , Category= Category.Electronics},
                new Product { Name = "Smartphone", Price = 800, Description = "Latest model", IsAvailable = true, Category = Category.Electronics },
                new Product { Name = "Milk", Price = 2, Description = "somethings!!!", IsAvailable = false , Category = Category.Groceries},
                new Product { Name = "T-Shirt", Price = 15, Description = "Nike T-Shirt", IsAvailable = false , Category = Category.Clothing },
                new Product { Name = "SmartPhone2", Price = 800, Description = "Latest model", IsAvailable = true, Category = Category.Electronics },
                new Product { Name = "Laptop", Price = 800, Description = "Latest model", IsAvailable = false , Category = Category.Electronics }
            );

            context.SaveChanges();
        }
    }
}