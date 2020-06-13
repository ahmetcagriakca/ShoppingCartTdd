using ShoppingCart.UnitTests.Models.Enums;

namespace ShoppingCart.UnitTests.Models
{
    public class Campaign
    {
        public Category Category { get; }
        public double DiscountPercentage { get; }
        public int MinimumItemCount { get; }
        public DiscountType DiscountType { get; }


        public Campaign(Category category, in double discountPercentage, in int minimumItemCount, DiscountType discountType)
        {
            Category = category;
            DiscountPercentage = discountPercentage;
            MinimumItemCount = minimumItemCount;
            DiscountType = discountType;
        }
    }
}