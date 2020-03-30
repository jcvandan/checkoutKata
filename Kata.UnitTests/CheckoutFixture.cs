using FluentAssertions;
using Xunit;

namespace Kata.UnitTests
{
    public class CheckoutFixture
    {
        [Fact]
        public void Total_NoScannedItem_ShouldBeZero()
        {
            var checkout = new Checkout();
            checkout.Total().Should().Be(0m);
        }
        
        [Fact]
        public void TotalShouldMatch_SingleItemUnitPrice_WhenSingleItem_IsScanned()
        {
            // Arrange
            const string sku = "A99";
            const decimal unitPrice = 0.5m;
            
            // Act
            var checkout = new Checkout();
            checkout.Scan(new Item(sku, unitPrice));
            
            // Assert
            checkout.Total().Should().Be(0.5m);
        }
    }
}