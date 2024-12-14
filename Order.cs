using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_promise
{
    internal class Order
    {
        private Dictionary<string, OrderItem> _items = new Dictionary<string, OrderItem>();
    
        public void AddProduct(Product product, int quantity)
        {
            var existingItem = _items.TryAdd(product.Name, new OrderItem(product, quantity));
            if (!existingItem)
            {
                if (_items.TryGetValue(product.Name, out var orderItem))
                {
                    orderItem.Quantity += quantity;
                }
            }
        }

        public void RemoveProduct(Product product, int quantity)
        {
            if (_items.ContainsKey(product.Name))
            { 
                _items.Remove(product.Name);
            }
            else
            {
                Console.WriteLine("Dany produkt nie znajduje się w zamówieniu");
            }
        }
    }
}
