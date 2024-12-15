using project_promise;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

class Program
{
    private static string ProductName { get; set; }
    private static int ProductQty {  get; set; }
	public static void ProductValidation(Order order)
	{
        bool correctProduct = false;
        bool correctProductQty = false;
        do
        {
            Console.WriteLine("Podaj nazwę produktu: ");
            ProductName = Console.ReadLine();
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
                        ProductValidation(order);
						
						order.AddProduct(ProductName, ProductQty);

						break;
					}
				case "2":
					{
                        ProductValidation(order);

                        order.RemoveProduct(ProductName, ProductQty);

                        break;
					}
				case "3":
					{
						foreach (var product in order.orderItems)
						{
							Console.WriteLine($"Produkt: {product.Value.Product.Name}, ilość: {product.Value.Quantity}");
						}
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
}