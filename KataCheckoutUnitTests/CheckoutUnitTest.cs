using System.Collections.Generic;
using KataCheckout;
using NUnit.Framework;


namespace KataCheckoutUnitTests
{
    [TestFixture]
    public class CheckoutUnitTest
    {
        
        private int Price(string products)
        {
            var co = new Checkout(new List<IRule>
            {
                new SetOfProductsRule("AAA", 130),
                new SetOfProductsRule("A", 50),
                new SetOfProductsRule("B", 30),
                new SetOfProductsRule("C", 20),
                new SetOfProductsRule("D", 15),
            });

            foreach (char product in products)
            {
                co.Scan(product);
            }

            return co.Total();
        }
        

        [Test]
        public void NoProducts()
        {
            Assert.AreEqual(0, Price(""));
        }

        [Test]
        public void OneProduct()
        {
            Assert.AreEqual(50, Price("A"));
        }

        [Test]
        public void AnotherProduct()
        {
            Assert.AreEqual(30, Price("B"));
        }

        [Test]
        public void TwoProducts()
        {
            Assert.AreEqual(80, Price("AB"));
        }

        [Test]
        public void FourProducts()
        {
            Assert.AreEqual(115, Price("CDBA"));
        }

        [Test]
        public void ThreeOfTheSameProduct()
        {
            Assert.AreEqual(130, Price("AAA"));
        }

    }
}
