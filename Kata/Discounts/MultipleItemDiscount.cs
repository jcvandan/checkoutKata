using System;
using System.Collections.Generic;
using System.Linq;
using Kata.Models;

namespace Kata.Discounts
{
    public class MultipleItemDiscount : IDiscount
    {
        private readonly int _quantity;
        private readonly decimal _discountPrice;

        public string SkuId { get; }

        public MultipleItemDiscount(string skuId, int quantity, decimal discountPrice)
        {
            SkuId = skuId;
            _quantity = quantity;
            _discountPrice = discountPrice;
        }

        public bool IsMatch(IEnumerable<Item> matchingItems)
        {
            if (!matchingItems.Any())
                return false;
            if (matchingItems.Select(i => i.Sku).Distinct().Count() > 1)
                throw new ArgumentException("Please pass matching Sku items");

            return matchingItems.First().Sku == SkuId && matchingItems.Count() >= _quantity;
        }

        public decimal DiscountedPrice(IEnumerable<Item> matchingItems)
        {
            int totalItems = matchingItems.Count();
            int remainderItems = totalItems - _quantity;
            return _discountPrice + remainderItems * matchingItems.First().UnitPrice;
        }
    }
}