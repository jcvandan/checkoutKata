using FluentAssertions;
using Kata.Discounts;
using Kata.Models;
using Xunit;

namespace Kata.UnitTests
{
    public class MultipleItemDiscountFixture
    {
        [Fact]
        public void IsMatch_ShouldReturnTrue_IfItemsPassed_MatchDiscountProperties()
        {
            // Arrange
            var discount = new MultipleItemDiscount("A99", 3, 1.3m);

            var items = new[]
            {
                new Item("A99", 0.5m),
                new Item("A99", 0.5m),
                new Item("A99", 0.5m)
            };
            
            // Act
            bool isMatch = discount.IsMatch(items);
            
            // Assert
            isMatch.Should().BeTrue();
        }
        
        [Fact]
        public void DiscountPrice_ShouldReturnDiscountPrice_IfPropertiesMatch()
        {
            // Arrange
            var discount = new MultipleItemDiscount("A99", 3, 1.3m);

            var items = new[]
            {
                new Item("A99", 0.5m),
                new Item("A99", 0.5m),
                new Item("A99", 0.5m)
            };
            
            // Act
            decimal discountPrice = discount.DiscountedPrice(items);
            
            // Assert
            discountPrice.Should().Be(1.3m);
        }
    }
}