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
            decimal total = 0m;

            foreach (var skuBatch in _items.GroupBy(i => i.Sku))
            {
                var matchingDiscounts = _discounts.Where(d => d.SkuId == skuBatch.Key);
                if (matchingDiscounts.Any())
                {
                    foreach (var discount in matchingDiscounts)
                    {
                        total += GetDiscountedPrice(discount, skuBatch);
                    }
                }
                else
                {
                    total += skuBatch.Sum(b => b.UnitPrice);
                }
            }

            return total;
        }

        private static decimal GetDiscountedPrice(IDiscount discount, IGrouping<string, Item> skuBatch)
        {
            return discount.IsMatch(skuBatch)
                ? discount.DiscountedPrice(skuBatch)
                : skuBatch.Sum(b => b.UnitPrice);
        }

        public void Scan(Item item)
        {
            _items.Add(item);
        }
    }
}