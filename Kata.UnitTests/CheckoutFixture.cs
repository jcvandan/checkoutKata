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
    }
}