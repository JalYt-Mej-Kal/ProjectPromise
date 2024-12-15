using project_promise;
using System;
using System.Xml.Serialization;

class Program
{
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
						string productName;
						bool correctProduct = false;
						var productQty = 0;
						bool correctProductQty = false;
						do
						{
							Console.WriteLine("Podaj nazwę dodawanego produktu: ");
							productName = Console.ReadLine();
							correctProduct = order.CheckIfProductExists(productName);
							if (!correctProduct)
							{
								Console.WriteLine("Nazwa produktu jest nieprawidłowa, bądź produktu nie ma w sklepie");
							}
						}
						while (!correctProduct);

						do
						{
							Console.WriteLine("Podaj liczbę dodawanych produktów: ");
							var productQtyString = Console.ReadLine();
							correctProductQty = int.TryParse(productQtyString, out productQty) && productQty > 0;
							if (!correctProductQty)
							{
								Console.WriteLine("Podano nieprawiłową liczbę");
							}
						}
						while (!correctProductQty);

						order.AddProduct(productName, productQty);

						break;
					}
				case "2":
					{
                        string productName;
                        bool correctProduct = false;
                        var productQty = 0;
                        bool correctProductQty = false;
                        do
                        {
                            Console.WriteLine("Podaj nazwę usuwanego produktu: ");
                            productName = Console.ReadLine();
                            correctProduct = order.CheckIfProductExists(productName);
                            if (!correctProduct)
                            {
                                Console.WriteLine("Nazwa produktu jest nieprawidłowa, bądź produktu nie ma w zamówieniu");
                            }
                        }
                        while (!correctProduct);

                        do
                        {
                            Console.WriteLine("Podaj liczbę usuwanych produktów: ");
                            var productQtyString = Console.ReadLine();
                            correctProductQty = int.TryParse(productQtyString, out productQty) && productQty > 0;
                            if (!correctProductQty)
                            {
                                Console.WriteLine("Podano nieprawiłową liczbę");
                            }
                        }
                        while (!correctProductQty);

                        break;
					}
				case "3":
					{
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
		Console.ReadLine();
	}
}