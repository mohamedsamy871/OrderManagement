using Microsoft.EntityFrameworkCore;
using OrderManagement.Models.DomainModels;
using OrderManagement.Models.Enums;

namespace OrderManagement.Services
{
    public interface ILoyalityService
    {
        Task<CustomerSegment> Calculate(int customerId);
    }
    public class LoyalityCalculationService : ILoyalityService
    {
        private readonly DataContext _dataContext;

        public LoyalityCalculationService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<CustomerSegment> Calculate(int customerId)
        {
            int completedOrders = await _dataContext.Orders
           .Where(o => o.Customer.Id == customerId && o.Status == OrderStatus.Delivered&& o.DeliveredAt.HasValue
            && o.DeliveredAt>DateTime.UtcNow.AddYears(-1))
               .CountAsync();
            var segment = completedOrders switch
            {
                0 => CustomerSegment.New,
                >= 1 and <= 4 => CustomerSegment.Regular,
                >= 5 and <= 100 => CustomerSegment.Loyal,
                > 100=>CustomerSegment.VIP
            };
            return segment;
        }
    }
}
