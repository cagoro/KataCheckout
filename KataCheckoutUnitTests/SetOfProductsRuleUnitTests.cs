using System.Collections.Generic;
using KataCheckout;
using NUnit.Framework;

namespace KataCheckoutUnitTests
{
    [TestFixture]
    public class SetOfProductsRuleUnitTests
    {
        [Test]
        public void SingleProduct_RuleAppliesToTheProduct_RuleApply()
        {
            var rule = new SetOfProductsRule("A", 1);
            var products = new List<char> { 'A'};
            Assert.AreEqual(1, rule.ConsumeProducts(products));
            Assert.AreEqual(0, products.Count);
        }

        [Test]
        public void MultipleProducts_RuleForOneProduct_RulesApplies()
        {
            var rule = new SetOfProductsRule("A", 1);
            var products = new List<char> { 'D','A','B','B'};
            var expectedRemainingProduts = new List<char> {'D', 'B', 'B'};
            Assert.AreEqual(1, rule.ConsumeProducts(products));
            Assert.AreEqual(expectedRemainingProduts, products);
        }

        [Test]
        public void MultipleProducts_RulesForMoreThanOneProductButNotAllProductsFound_RuleDoesNotApply()
        {
            var rule = new SetOfProductsRule("CAB", 1);
            var products = new List<char> { 'A', 'B', 'B' };
            var expectedRemainingProduts = new List<char> { 'A', 'B', 'B' };
            Assert.AreEqual(0, rule.ConsumeProducts(products));
            Assert.AreEqual(expectedRemainingProduts, products);
        }

        [Test]
        public void MultipleProducts_RulesForMoreThanOneProductAndAllProductsFound_RuleApplies()
        {
            var rule = new SetOfProductsRule("CAB", 1);
            var products = new List<char> { 'A', 'B', 'B', 'C' };
            var expectedRemainingProduts = new List<char> { 'B' };
            Assert.AreEqual(1, rule.ConsumeProducts(products));
            Assert.AreEqual(expectedRemainingProduts, products);
        }

        [Test]
        public void MultipleProducts_RulesForMoreThanOneProductAndAllProductsFoundTwice_RuleAppliedTwicePriceIsDoubled()
        {
            var rule = new SetOfProductsRule("CAB", 1);
            var products = new List<char> { 'A', 'B', 'B', 'C', 'A', 'C' };
            Assert.AreEqual(2, rule.ConsumeProducts(products));
            Assert.AreEqual(0, products.Count);
        }

        [Test]
        public void SingleProduct_RulesForTheSameProductTwice()
        {
            var rule = new SetOfProductsRule("AA", 1);
            var products = new List<char> { 'A' };
            Assert.AreEqual(0, rule.ConsumeProducts(products));
            Assert.AreEqual(new List<char> {'A'}, products.Count);
        }

    }
}