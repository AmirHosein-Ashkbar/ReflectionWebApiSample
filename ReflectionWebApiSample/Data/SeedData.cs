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
                new Product { Name = "Laptop", Price = 1500, Description = "Gaming Laptop", IsAvailable = true, Category = Category.Electronics },
                new Product { Name = "Smartphone", Price = 800, Description = "Latest model smartphone", IsAvailable = true, Category = Category.Electronics },
                new Product { Name = "Headphones", Price = 150, Description = "Wireless noise-cancelling headphones", IsAvailable = true, Category = Category.Electronics },
                new Product { Name = "TV", Price = 1200, Description = "55-inch 4K Smart TV", IsAvailable = false, Category = Category.Electronics },
                new Product { Name = "Smartwatch", Price = 250, Description = "Water-resistant smartwatch", IsAvailable = true, Category = Category.Electronics },

                new Product { Name = "Jeans", Price = 50, Description = "Slim-fit denim jeans", IsAvailable = true, Category = Category.Clothing },
                new Product { Name = "T-Shirt", Price = 20, Description = "Cotton t-shirt", IsAvailable = true, Category = Category.Clothing },
                new Product { Name = "Jacket", Price = 120, Description = "Leather jacket", IsAvailable = false, Category = Category.Clothing },
                new Product { Name = "Sneakers", Price = 90, Description = "Running sneakers", IsAvailable = true, Category = Category.Clothing },
                new Product { Name = "Dress", Price = 75, Description = "Summer floral dress", IsAvailable = true, Category = Category.Clothing },

                new Product { Name = "Vitamin C", Price = 15, Description = "Vitamin C supplements", IsAvailable = true, Category = Category.Health },
                new Product { Name = "Pain Reliever", Price = 10, Description = "Ibuprofen 200mg", IsAvailable = true, Category = Category.Health },
                new Product { Name = "Face Mask", Price = 5, Description = "Disposable surgical masks", IsAvailable = true, Category = Category.Health },
                new Product { Name = "Hand Sanitizer", Price = 7, Description = "Alcohol-based hand sanitizer", IsAvailable = true, Category = Category.Health },
                new Product { Name = "Thermometer", Price = 25, Description = "Digital thermometer", IsAvailable = true, Category = Category.Health },

                new Product { Name = "Rice", Price = 12, Description = "5kg bag of basmati rice", IsAvailable = true, Category = Category.Groceries },
                new Product { Name = "Pasta", Price = 8, Description = "500g pack of spaghetti", IsAvailable = true, Category = Category.Groceries },
                new Product { Name = "Milk", Price = 2.5M, Description = "1 liter of whole milk", IsAvailable = true, Category = Category.Groceries },
                new Product { Name = "Apples", Price = 3, Description = "1kg of fresh apples", IsAvailable = true, Category = Category.Groceries },
                new Product { Name = "Orange Juice", Price = 4, Description = "1 liter of freshly squeezed orange juice", IsAvailable = true, Category = Category.Groceries }
            );

            context.SaveChanges();
        }
    }
}