using System;

namespace KataCheckout
{

    public class Rule
    {
        private readonly string _products;
        private readonly int _price;
        

        public Rule(string products, int price)
        {
            _products = products;
            _price = price;
        }

        public string Products
        {
            get { return _products; }
        }

        public int Price
        {
            get { return _price; }
        }
    }


    
}