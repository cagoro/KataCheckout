using System;
using System.Collections.Generic;

namespace KataCheckout
{

    public class SetOfProductsRule : IRule
    {
        private readonly string _products;
        private readonly int _price;
        

        public SetOfProductsRule(string products, int price)
        {
            _products = products;
            _price = price;
        }

        public int ConsumeProducts(List<char> products)
        {
            throw new NotImplementedException();
        }
    }
}