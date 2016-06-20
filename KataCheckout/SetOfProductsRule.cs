using System.Collections.Generic;
using System.Linq;

namespace KataCheckout
{

    public class SetOfProductsRule : IRule
    {
        private readonly List<char> _productsSet;
        private readonly int _price;
        

        public SetOfProductsRule(string productsSet, int price)
        {
            _productsSet = productsSet.ToList();
            _price = price;
        }

        public int ConsumeProducts(List<char> products)
        {
            var totalPrice = 0;
            while (IsRuleApplicable(products))
            {
                ConsumeProductsFromProductList(products);
                totalPrice += _price;
            }
            return totalPrice;
        }

        private bool IsRuleApplicable(IEnumerable<char> products)
        {
            var currentProductSet = new List<char>(_productsSet);
            foreach (var product in products)
            {
                if (currentProductSet.Contains(product))
                {
                    currentProductSet.Remove(product);
                }
            }
            return currentProductSet.Count == 0;
        }

        private void ConsumeProductsFromProductList(ICollection<char> products)
        {
            foreach (var product in _productsSet)
            {
                products.Remove(product);
            }
        }
    }
}