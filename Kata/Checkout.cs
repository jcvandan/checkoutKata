using System.Collections.Generic;
using System.Linq;
using Kata.Discounts;
using Kata.Models;

namespace Kata
{
    public class Checkout
    {
        private readonly IEnumerable<IDiscount> _discounts;
        private readonly List<Item> _items;

        /// <summary>
        /// In a real world situation these would be loaded from storage and injected on object creation
        /// </summary>
        public Checkout(IEnumerable<IDiscount> discounts = null)
        {
            _discounts = discounts ?? new List<IDiscount>();
            _items = new List<Item>();
        }
        
        public decimal Total()
        {
            return _items.Sum(i => i.UnitPrice);
        }
 
        public void Scan(Item item)
        {
            _items.Add(item);
        }
    }
}