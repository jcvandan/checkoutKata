using FluentAssertions;
using Kata.Models;
using Xunit;

namespace Kata.UnitTests
{
    public class CheckoutFixture
    {
        private readonly Item _apple = new Item("A99", 0.5m);
        private readonly Item _biscuits = new Item("B15", 0.3m);
        private readonly Item _cola = new Item("C40", 0.6m);
        
        [Fact]
        public void Total_NoScannedItem_ShouldBeZero()
        {
            var checkout = new Checkout();
            checkout.Total().Should().Be(0m);
        }
        
        [Fact]
        public void TotalShouldMatch_SingleItemUnitPrice_WhenSingleItem_IsScanned()
        {
            // Act
            var checkout = new Checkout();
            checkout.Scan(_apple);
            
            // Assert
            checkout.Total().Should().Be(0.5m);
        }
        
        [Fact]
        public void TotalShouldMatch_SumOfMultipleUnitPrices_WhenManyItems_AreScanned()
        {
            // Act
            var checkout = new Checkout();
            checkout.Scan(_apple);
            checkout.Scan(_biscuits);
            checkout.Scan(_cola);
            
            // Assert
            checkout.Total().Should().Be(1.4m);
        }
        
        [Fact]
        public void DiscountShould_SumOfMultipleUnitPrices_WhenManyItems_AreScanned()
        {
            // Act
            var checkout = new Checkout();
            checkout.Scan(_apple);
            checkout.Scan(_biscuits);
            checkout.Scan(_cola);
            
            // Assert
            checkout.Total().Should().Be(1.4m);
        }
    }
}