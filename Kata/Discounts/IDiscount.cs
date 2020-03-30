using System.Collections.Generic;
using Kata.Models;

namespace Kata.Discounts
{
    public interface IDiscount
    {
        string SkuId { get; }
        bool IsMatch(IEnumerable<Item> matchingItems);
        decimal DiscountedPrice(IEnumerable<Item> matchingItems);
    }
}