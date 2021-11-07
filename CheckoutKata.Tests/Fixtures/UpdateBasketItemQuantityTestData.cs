using System.Collections;
using System.Collections.Generic;

namespace CheckoutKata.Tests.Fixtures
{
    public class UpdateBasketItemQuantityTestData : IEnumerable<object[]>
    {
        private readonly BasketServiceFixtures _fixtures = new();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { _fixtures.Products[0], 3 };
            yield return new object[] { _fixtures.Products[1], 4 };
            yield return new object[] { _fixtures.Products[2], 5 };
            yield return new object[] { _fixtures.Products[3], 6 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}