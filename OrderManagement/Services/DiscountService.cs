using OrderManagement.Models.DomainModels;
using OrderManagement.Models.Enums;

namespace OrderManagement.Services
{
    public interface IDiscountService
    {
        decimal ApplyDiscount(CustomerSegment segment, decimal orderTotal);
    }
    public class DiscountService: IDiscountService
    {
        public decimal ApplyDiscount(CustomerSegment segment, decimal orderTotal)
        {
            var discount = segment switch
            {
                CustomerSegment.VIP => 0.15m,   // 15% discount
                CustomerSegment.Loyal => 0.10m, // 10% discount
                CustomerSegment.New => 0.05m, // 5% discount
                _ => 0.00m
            };

            return orderTotal * (1 - discount);
        }
    }
}
