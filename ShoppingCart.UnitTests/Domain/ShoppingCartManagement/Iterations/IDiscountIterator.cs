using System.Collections.Generic;
using ShoppingCart.UnitTests.Models;

namespace ShoppingCart.UnitTests.Domain.ShoppingCartManagement.Iterations
{
    public interface IDiscountIterator
    {
        //Iterating Campaign discount calculation
        Campaign Iterate(IEnumerable<Campaign> campaigns, Models.ShoppingCart cart);
    }
}
