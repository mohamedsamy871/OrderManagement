using OrderManagement.Models.DomainModels;

namespace OrderManagement.Services
{
    public interface IOrderService
    {
        Task<Order> HandleOrder(Order order);
    }
    public class OrderService:IOrderService
    {
        private readonly ILoyalityService _loyalityService;
        private readonly IDiscountService _discountService;

        public OrderService(ILoyalityService loyalityService, IDiscountService discountService)
        {
           _loyalityService = loyalityService;
            _discountService = discountService;
        }
        public async Task<Order> HandleOrder(Order order)
        {
            var customrSegment =await  _loyalityService.Calculate(order.CustomerId);
            var _orderTotal =  _discountService.ApplyDiscount(customrSegment, order.TotalAmount);
            order.TotalAmount = _orderTotal;
            return order;
        }
    }
}
