using System.Collections.Generic;
using System.Linq;
using CheckoutKata.Models;

namespace CheckoutKata.Services
{
    public class BasketService
    {
        public List<BasketItem> Basket { get; set; }

        public BasketService()
        {
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
                    basketItem.UpdateQuantity(quantity);
                }
                else
                {
                    Basket.Remove(basketItem);
                }
            }
            else if (product != null && quantity > 0)
            {
                Basket.Add(new BasketItem(product, quantity));
            }
        }
    }
}