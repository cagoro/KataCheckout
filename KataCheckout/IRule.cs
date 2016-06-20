using System.Collections.Generic;

namespace KataCheckout
{
    public interface IRule
    {
        int ConsumeProducts(List<char> products);
    }
}