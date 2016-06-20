using System.Collections.Generic;

namespace KataCheckout
{
    public class Checkout
    {
        private readonly List<IRule> _rulesInPriorityOrder;
        private readonly List<char> _productsScanned;

        public Checkout(List<IRule> rulesInPriorityOrderInPriorityOrder)
        {
            _productsScanned = new List<char>();
            _rulesInPriorityOrder = rulesInPriorityOrderInPriorityOrder;
        }

        public int Total()
        {
            var total = 0;

            var currentProductsScanned = new List<char>(_productsScanned);

            foreach (var rule in _rulesInPriorityOrder)
            {
                total += rule.ConsumeProducts(currentProductsScanned);
            }
            return total;
        }


        public void Scan(char product)
        {
            _productsScanned.Add(product);
        }
    }
}