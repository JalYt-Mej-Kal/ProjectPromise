using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_promise
{
    internal class Order
    {
        public Dictionary<string, OrderItem> orderItems = new Dictionary<string, OrderItem>();

        private Dictionary<string, Product> _products = new Dictionary<string, Product>
        {
            { "Laptop", new Product("Laptop", 2500m) },
            { "Klawiatura", new Product("Klawiatura", 120m) },
            { "Mysz", new Product("Mysz", 90m) },
            { "Monitor", new Product("Monitor", 1000m) },
            { "Kaczka debuggująca", new Product("Kaczka debuggująca", 66m) }
        };


        public void AddProduct(string productName, int quantity)
        {
            if (orderItems.TryGetValue(productName, out var orderItem))
            {
                orderItem.Quantity += quantity;
                Console.WriteLine($"Zamówienie dla produktu \"{productName}\" zostało zwiększone o {quantity}. Pozostało {orderItem.Quantity}.");
            }
            else
            {
                orderItems[productName] = new OrderItem(_products[productName], quantity);
                Console.WriteLine($"Dodano produkt \"{productName}\" do zamówienia. Ilość: {quantity}.");
            }
        }


        public void RemoveProduct(string productName, int quantity)
        {
            if (orderItems.TryGetValue(productName, out var orderItem))
            {
                if (quantity >= orderItem.Quantity)
                {
                    orderItems.Remove(productName);
                    Console.WriteLine($"Produkt \"{productName}\" został całkowicie usunięty z zamówienia.");
                }
                else
                {
                    orderItem.Quantity -= quantity;
                    Console.WriteLine($"Zamówienie dla produktu \"{productName}\" zostało zmniejszone o {quantity}. Pozostało {orderItem.Quantity}.");
                }
            }
            else
            {
                Console.WriteLine("Dany produkt nie znajduje się w zamówieniu.");
            }
        }


        public bool CheckIfProductExists(string productName)
        {
            if (_products.ContainsKey(productName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
