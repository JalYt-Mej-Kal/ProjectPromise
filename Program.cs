using project_promise;


class Program
{
    private static string ProductName { get; set; } = string.Empty;
    private static int ProductQty { get; set; }

    public static void Main(string[] args)
    {
        bool exit = false;
        var choice = string.Empty;
        var order = new Order();

        while (!exit)
        {
            Console.WriteLine("1. Dodaj produkt do zamówienia");
            Console.WriteLine("2. Usuń produkt z zamówienia");
            Console.WriteLine("3. Sprawdź wartość zamówienia");
            Console.WriteLine("4. Wyjdź");

            choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    {
                        Console.Clear();
                        ProductValidation(order);
                        order.AddProduct(ProductName, ProductQty);
                        
                        break;
                    }
                case "2":
                    {
                        Console.Clear();
                        ProductValidation(order);
                        order.RemoveProduct(ProductName, ProductQty);

                        break;
                    }
                case "3":
                    {
                        Console.Clear();
                        Console.WriteLine("Lista produktów: ");
                        foreach (var product in order.orderItems)
                        {
                            Console.WriteLine($"Produkt: {product.Value.Product.Name}, ilość: {product.Value.Quantity}, cena: {product.Value.TotalPrice()}");
                        }
                        var (totalPrice, totalDiscount) = order.CalculateTotalPrice();
                        Console.WriteLine($"Suma: {Math.Round(totalPrice, 2)}");
                        Console.WriteLine($"Rabat wynosi: {Math.Round(totalDiscount, 2)}");

                        break;
                    }
                case "4":
                    {
                        exit = true;

                        break;
                    }
                default:
                    {
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                        break;
                    }
            }
        }
    }

    public static void ProductValidation(Order order)
	{
        bool correctProduct = false;
        bool correctProductQty = false;
        do
        {
            Console.WriteLine("Podaj nazwę produktu: ");
            ProductName = Console.ReadLine() ?? string.Empty;
            correctProduct = order.CheckIfProductExists(ProductName);
            if (!correctProduct)
            {
                Console.WriteLine("Nazwa produktu jest nieprawidłowa, bądź produktu nie ma w sklepie");
            }
        }
        while (!correctProduct);

        do
        {
            Console.WriteLine("Podaj liczbę produktów: ");
            var productQtyString = Console.ReadLine();
            correctProductQty = int.TryParse(productQtyString, out var productQty) && productQty > 0;
            if (!correctProductQty)
            {
                Console.WriteLine("Podano nieprawiłową liczbę");
            }
            else
            {
                ProductQty = productQty;
            }
        }
        while (!correctProductQty);
    }
}