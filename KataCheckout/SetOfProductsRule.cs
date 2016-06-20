using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

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

        private bool IsRuleApplicable(List<char> products)
        {
            foreach (var product in _productsSet)
            {
                if (!products.Contains(product))
                {
                    return false;
                }
            }
            return true;
        }

        private void ConsumeProductsFromProductList(List<char> products)
        {
            foreach (var product in _productsSet)
            {
                products.Remove(product);
            }
        }
    }
}