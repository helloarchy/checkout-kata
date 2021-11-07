using System.Collections.Generic;
using CheckoutKata.Models;

namespace CheckoutKata.Tests.Fixtures
{
    public class BasketServiceFixtures
    {
        public List<Product> Products { get; set; }
        public List<Promotion> Promotions { get; set; }

        public BasketServiceFixtures()
        {
            SeedFixtures();
        }

        private void SeedFixtures()
        {
            var productA = new Product { SKU = "A", UnitPrice = 10.50M };
            var productB = new Product { SKU = "B", UnitPrice = 15.00M };
            var productC = new Product { SKU = "C", UnitPrice = 40.00M };
            var productD = new Product { SKU = "D", UnitPrice = 55.00M };
            Products = new List<Product> { productA, productB, productC, productD };

            var promotionB = new Promotion
            {
                Description = "3 for 40",
                RequiredProduct = productB,
                RequiredQuantity = 3,
                DiscountMultiplier = 40M / 45M, // 0.88...
                DiscountedProduct = productB
            };

            var promotionD = new Promotion
            {
                Description = "25% off for every 2 purchased together",
                RequiredProduct = productD,
                RequiredQuantity = 2,
                DiscountedProduct = productD,
                DiscountMultiplier = 0.25M,
            };

            Promotions = new List<Promotion> { promotionB, promotionD };
        }
    }
}