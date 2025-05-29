using OrderManagement.Models.DomainModels;
using OrderManagement.Models.Enums;
using OrderManagement.Services;
using Xunit;

namespace OrderManagement.Tests
{
    public class DiscountServiceTests
    {
        [Fact]
        public void LoyalCustomer_ShouldGet10PercentDiscount()
        {
            var service = new DiscountService();
            var result = service.ApplyDiscount(CustomerSegment.Loyal,100M);

            Assert.Equal(90m, result);
        }

    }
}
