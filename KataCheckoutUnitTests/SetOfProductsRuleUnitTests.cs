using System.Collections.Generic;
using KataCheckout;
using NUnit.Framework;

namespace KataCheckoutUnitTests
{
    [TestFixture]
    public class SetOfProductsRuleUnitTests
    {
        [Test]
        public void NoProducts()
        {
            var rule = new SetOfProductsRule("A", 1);
            var products = new List<char> { 'A'};
            Assert.AreEqual(1, rule.ConsumeProducts(products));
            Assert.AreEqual(0, products.Count == 0);
        }
        
    }
}