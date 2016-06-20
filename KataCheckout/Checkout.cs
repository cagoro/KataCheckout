using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace KataCheckout
{
    public class Checkout
    {
        private readonly Rule[] _rules;
        private string _productsScanned;

        public Checkout(Rule[] rules)
        {
            _rules = rules.OrderByDescending(x => x.Products.Length).ToArray();

            _productsScanned = string.Empty;
        }

        public int Total()
        {
            int total = 0;

            _productsScanned = String.Join("", _productsScanned.ToCharArray().OrderByDescending(x => x));

            while (_productsScanned.Length != 0)
            {
                total += ApplyRules();
            }

            return total;
        }

        private int ApplyRules()
        {
            var totalPrice = 0;

            foreach (Rule rule in _rules)
            {
                if (_productsScanned.Contains(rule.Products))
                {
                    totalPrice += rule.Price;
                    _productsScanned = _productsScanned.Replace(rule.Products, "");
                }
            }
            return totalPrice;
        }


        public void Scan(char product)
        {
            _productsScanned = _productsScanned + product;
        }
    }
}