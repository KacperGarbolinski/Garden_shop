using SklepOgrodniczy.Models;
using SklepOgrodniczy.Services;
using static System.Formats.Asn1.AsnWriter;

var store = new Store();
var cart = new Cart();
bool running = true;

while (running)
{
    Console.WriteLine("\n=== SKLEP OGRODNICZY ===");
    Console.WriteLine("1. Wyświetl produkty");
    Console.WriteLine("2. Dodaj produkt do koszyka");
    Console.WriteLine("3. Usuń produkt z koszyka");
    Console.WriteLine("4. Pokaż koszyk");
    Console.WriteLine("5. Finalizuj zakup");
    Console.WriteLine("0. Wyjdź");
    Console.Write("Wybierz opcję: ");

    switch (Console.ReadLine())
    {
        case "1":
            Console.WriteLine("\n--- Lista produktów ---");
            foreach (var p in store.Products)
                Console.WriteLine($"{p.Id}. {p.Name} - {p.Price:C} ({p.Stock} dostępnych)");
            break;

        case "2":
            Console.Write("Podaj ID produktu: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var product = store.GetProductById(id);
                if (product != null)
                {
                    Console.Write("Podaj ilość: ");
                    if (int.TryParse(Console.ReadLine(), out int qty) && qty > 0 && qty <= product.Stock)
                    {
                        cart.AddToCart(product, qty);
                        Console.WriteLine("Dodano do koszyka.");
                    }
                    else
                        Console.WriteLine("Nieprawidłowa ilość.");
                }
                else
                    Console.WriteLine("Produkt nie istnieje.");
            }
            break;

        case "3":
            Console.Write("Podaj ID produktu do usunięcia: ");
            if (int.TryParse(Console.ReadLine(), out int removeId))
            {
                cart.RemoveFromCart(removeId);
                Console.WriteLine("Usunięto z koszyka.");
            }
            break;

        case "4":
            Console.WriteLine("\n--- Zawartość koszyka ---");
            cart.DisplayCart();
            break;

        case "5":
            Console.WriteLine("\n--- Finalizacja zakupu ---");
            cart.DisplayCart();
            var total = cart.FinalizePurchase();
            Console.WriteLine($"\nŁączna kwota: {total:C}");
            break;

        case "0":
            running = false;
            break;

        default:
            Console.WriteLine("Nieprawidłowy wybór.");
            break;
    }
}

Console.WriteLine("Dziękujemy za zakupy!");
