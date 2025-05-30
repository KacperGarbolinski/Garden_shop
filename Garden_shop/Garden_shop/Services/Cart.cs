using SklepOgrodniczy.Models;

namespace SklepOgrodniczy.Services;

public class Cart
{
    public List<CartItem> Items { get; private set; } = new List<CartItem>();

    public void AddToCart(Product product, int quantity)
    {
        var item = Items.FirstOrDefault(i => i.Product.Id == product.Id);
        if (item == null)
        {
            Items.Add(new CartItem { Product = product, Quantity = quantity });
        }
        else
        {
            item.Quantity += quantity;
        }
    }

    public void RemoveFromCart(int productId)
    {
        var item = Items.FirstOrDefault(i => i.Product.Id == productId);
        if (item != null)
        {
            Items.Remove(item);
        }
    }

    public void DisplayCart()
    {
        if (Items.Count == 0)
        {
            Console.WriteLine("Koszyk jest pusty.");
            return;
        }

        foreach (var item in Items)
        {
            Console.WriteLine($"{item.Product.Name} - {item.Quantity} x {item.Product.Price:C} = {(item.Quantity * item.Product.Price):C}");
        }
    }

    public decimal FinalizePurchase()
    {
        decimal total = 0;
        foreach (var item in Items)
        {
            item.Product.Stock -= item.Quantity;
            total += item.Product.Price * item.Quantity;
        }

        Items.Clear();
        return total;
    }
}
