using ShoppingCart.UnitTests.Models.Enums;

namespace ShoppingCart.UnitTests.Models
{
    public class Campaign
    {
        public Category Category { get; }
        public double Discount { get; }
        public int MinimumItemCount { get; }
        public DiscountType DiscountType { get; }


        public Campaign(Category category, in double discount, in int minimumItemCount, DiscountType discountType)
        {
            Category = category;
            Discount = discount;
            MinimumItemCount = minimumItemCount;
            DiscountType = discountType;
        }
    }
}