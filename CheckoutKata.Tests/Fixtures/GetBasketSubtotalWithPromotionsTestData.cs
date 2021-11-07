using System.Collections;
using System.Collections.Generic;
using CheckoutKata.Models;

namespace CheckoutKata.Tests.Fixtures
{
    public class GetBasketSubtotalWithPromotionsTestData : IEnumerable<object[]>
    {
        private readonly BasketServiceFixtures _fixtures = new();

        public IEnumerator<object[]> GetEnumerator()
        {
            var batch1 = new List<(Product, int)>
            {
                (_fixtures.Products[1], 3)
            };

            var batch2 = new List<(Product, int)>
            {
                (_fixtures.Products[3], 2)
            };
            
            var batch3 = new List<(Product, int)>
            {
                (_fixtures.Products[3], 3)
            };
            
            var batch4 = new List<(Product, int)>
            {
                (_fixtures.Products[1], 4)
            };

            yield return new object[] { batch1, 40.00M };
            yield return new object[] { batch2, 27.50M };
            yield return new object[] { batch3, 82.50M };
            yield return new object[] { batch4, 55.00M };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}