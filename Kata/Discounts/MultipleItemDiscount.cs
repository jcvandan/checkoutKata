﻿using System;
using System.Collections.Generic;
using System.Linq;
using Kata.Models;

namespace Kata.Discounts
{
    public class MultipleItemDiscount : IDiscount
    {
        private readonly string _skuId;
        private readonly int _quantity;
        private readonly decimal _discountPrice;

        public MultipleItemDiscount(string skuId, int quantity, decimal discountPrice)
        {
            _skuId = skuId;
            _quantity = quantity;
            _discountPrice = discountPrice;
        }
        
        public bool IsMatch(IEnumerable<Item> matchingItems)
        {
            if (matchingItems.Select(i => i.Sku).Distinct().Count() > 1)
                throw new ArgumentException("Please pass matching Sku items");

            return false;
        }

        public decimal DiscountPrice(IEnumerable<Item> matchingItems)
        {
            return 0m;
        }
    }
}