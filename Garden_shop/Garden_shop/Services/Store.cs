using SklepOgrodniczy.Models;

namespace SklepOgrodniczy.Services;

public class Store
{
    public List<Product> Products { get; private set; }

    public Store()
    {
        Products = new List<Product>
        {
            new Product { Id = 1, Name = "Nawóz uniwersalny", Price = 25.99m, Stock = 10 },
            new Product { Id = 2, Name = "Konewka", Price = 15.50m, Stock = 5 },
            new Product { Id = 3, Name = "Ziemia ogrodowa 50L", Price = 22.00m, Stock = 8 },
            new Product { Id = 4, Name = "Sekator rêczny", Price = 34.90m, Stock = 4 },
            new Product { Id = 5, Name = "Grabie stalowe", Price = 29.99m, Stock = 6 }
        };
    }

    public Product? GetProductById(int id) => Products.FirstOrDefault(p => p.Id == id);
}
