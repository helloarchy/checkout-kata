using CheckoutKata.Models;
using CheckoutKata.Services;
using CheckoutKata.Tests.Fixtures;
using Xunit;

namespace CheckoutKata.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void UpdateBasketItemQuantity_NoProduct_DoesNothing()
        {
            var basketService = new BasketService();
            basketService.UpdateBasketItemQuantity(null, 0);

            Assert.Empty(basketService.Basket);
        }
        
        [Theory]
        [ClassData(typeof(UpdateBasketItemQuantityTestData))]
        public void UpdateBasketItemQuantity_ManyProducts_AddsAll(Product product, int quantity)
        {
            var basketService = new BasketService();
            basketService.UpdateBasketItemQuantity(product, quantity);

            Assert.NotEmpty(basketService.Basket);
            Assert.Contains(basketService.Basket, item => item.Product == product && item.Quantity == quantity);
        }
        
        [Fact]
        public void GetBasketSubtotal_NoProduct_ReturnsZero()
        {
            var basketService = new BasketService();
            var expected = 0;
            
            basketService.UpdateBasketItemQuantity(null, 0);
            var actual = basketService.GetBasketSubtotal();

            Assert.Equal(expected, actual);
        }
    }
}