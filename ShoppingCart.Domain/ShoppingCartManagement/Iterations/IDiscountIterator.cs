using System.Collections.Generic;
using ShoppingCart.Domain.Models;

namespace ShoppingCart.Domain.ShoppingCartManagement.Iterations
{
    public interface IDiscountIterator
    {
        //Iterating Campaign discount calculation
        Campaign Iterate(IEnumerable<Campaign> campaigns, Models.ShoppingCart cart);
    }
}
