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
                CustomerSegment.VIP => 0.15m,  
                CustomerSegment.Loyal => 0.10m, 
                CustomerSegment.New => 0.05m, 
                _ => 0.00m
            };

            return orderTotal * (1 - discount);
        }
    }
}
