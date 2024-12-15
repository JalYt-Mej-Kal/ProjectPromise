

namespace project_promise
{
    internal class Order
    {
        public Dictionary<string, OrderItem> orderItems = new Dictionary<string, OrderItem>(StringComparer.OrdinalIgnoreCase);

        private Dictionary<string, Product> _products = new Dictionary<string, Product>(StringComparer.OrdinalIgnoreCase)
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
                Console.WriteLine($"Zamówienie dla produktu: {productName} zostało zwiększone o {quantity}. Pozostało {orderItem.Quantity}.");
            }
            else
            {
                orderItems[productName] = new OrderItem(_products[productName], quantity);
                Console.WriteLine($"Dodano produkt: {productName} do zamówienia. Ilość: {quantity}.");
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
                    Console.WriteLine($"Zamówienie dla produktu \"{productName}\" zostało zmniejszone o {quantity}. Ilość: {orderItem.Quantity}.");
                }
            }
            else
            {
                Console.WriteLine("Dany produkt nie znajduje się w zamówieniu.");
            }
        }

        public (decimal totalPrice, decimal totalDiscount) CalculateTotalPrice()
        {
            decimal totalOrderDiscount = 0;

            var sortedProducts = orderItems.Values
                        .SelectMany(order => Enumerable.Repeat(order.Product, order.Quantity))
                        .OrderBy(product => product.Price)
                        .ToList();

            decimal discount = 0;

            if (sortedProducts.Count >= 2)
            {
                var secondCheapest = sortedProducts[0];
                discount = secondCheapest.Price * 0.10m;
            }

            if (sortedProducts.Count >= 3)
            {
                var thirdCheapest = sortedProducts[0];
                decimal alternativeDiscount = thirdCheapest.Price * 0.20m;
                if (alternativeDiscount > discount)
                {
                    discount = alternativeDiscount;
                }
            }

            decimal totalPrice = sortedProducts.Sum(product => product.Price);
            totalPrice -= discount;

            if (totalPrice > 5000)
            {
                totalOrderDiscount = 0.05m * totalPrice;
                totalPrice = totalPrice - totalOrderDiscount;
            }
            
            return (totalPrice, totalOrderDiscount + discount);
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
