using System.Collections.Generic;
using Kata.Models;

namespace Kata.Discounts
{
    public interface IDiscount
    {
        bool IsMatch(IEnumerable<Item> matchingItems);
        decimal DiscountPrice(IEnumerable<Item> matchingItems);
    }
}