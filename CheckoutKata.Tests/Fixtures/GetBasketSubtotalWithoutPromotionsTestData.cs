using System.Collections;
using System.Collections.Generic;
using CheckoutKata.Models;

namespace CheckoutKata.Tests.Fixtures
{
    public class GetBasketSubtotalWithoutPromotionsTestData : IEnumerable<object[]>
    {
        private readonly BasketServiceFixtures _fixtures = new();

        public IEnumerator<object[]> GetEnumerator()
        {
            var batch1 = new List<(Product, int)>
            {
                (_fixtures.Products[0], 1), (_fixtures.Products[2], 1)
            };

            var batch2 = new List<(Product, int)>
            {
                (_fixtures.Products[0], 3), (_fixtures.Products[2], 4)
            };

            yield return new object[] { batch1, 50.50M };
            yield return new object[] { batch2, 191.50M };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}