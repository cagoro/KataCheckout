using System;
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
            foreach (var product in _productsSet)
            {
                if (!products.Contains(product))
                {
                    return 0;
                }
            }
            foreach (var product in _productsSet)
            {
                products.Remove(product);
            }
            return _price;
        }
    }
}