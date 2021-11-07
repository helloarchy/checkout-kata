using System;
using System.Collections.Generic;
using System.Linq;
using CheckoutKata.Models;

namespace CheckoutKata.Services
{
    public class BasketService
    {
        private readonly List<Promotion> _promotions;
        public List<BasketItem> Basket { get; }

        public BasketService(List<Promotion> promotions)
        {
            _promotions = promotions;
            Basket = new List<BasketItem>();
        }
        
        /// <summary>
        /// Update the basket quantity for a given product
        /// </summary>
        public void UpdateBasketItemQuantity(Product product, int quantity)
        {
            var basketItem = Basket.FirstOrDefault(basketItem => basketItem.Product.SKU == product.SKU);
            if (basketItem != null && basketItem.Quantity != quantity)
            {
                if (quantity != 0)
                {
                    basketItem.Quantity = quantity;
                    UpdateBasketItemPrice(basketItem);
                }
                else
                {
                    Basket.Remove(basketItem);
                }
            }
            else if (product != null && quantity > 0)
            {
                var newBasketItem = new BasketItem(product, quantity);
                Basket.Add(newBasketItem);
                UpdateBasketItemPrice(newBasketItem);
            }
        }

        
        private void UpdateBasketItemPrice(BasketItem basketItem)
        {
            var promotion = _promotions.FirstOrDefault(promotion 
                => promotion.RequiredProduct.SKU == basketItem.Product.SKU);
            if (promotion != null)
            {
                /* Apply discount only if the item is in the basket along with the
                 * product to apply the discount to (not always the same), and the
                 * required quantity is met. */
                var discountedItem = Basket.FirstOrDefault(item =>
                    item.Product.SKU == promotion.DiscountedProduct.SKU);
                if (basketItem.Product != null && basketItem.Quantity >= promotion.RequiredQuantity &&
                    discountedItem is { Quantity: > 0 })
                {
                    // Only apply discount to the required quantity
                    var requiredLimit = Math.Floor((decimal) basketItem.Quantity / promotion.RequiredQuantity) * promotion.RequiredQuantity;
                    var discountedPrice = (requiredLimit * discountedItem.Product.UnitPrice) * promotion.DiscountMultiplier;
                    var fullPriceItems = (basketItem.Quantity - requiredLimit) * discountedItem.Product.UnitPrice;

                    basketItem.Subtotal = discountedPrice + fullPriceItems;
                }
            }
            else
            {
                basketItem.Subtotal = basketItem.Product.UnitPrice * basketItem.Quantity;
            }
        }

        /// <summary>
        /// Get the total price across all items in the basket
        /// </summary>
        public decimal GetBasketSubtotal()
        {
            return Basket.Aggregate(0M, (acc, item) => (acc + item.Subtotal));
        }
    }
}