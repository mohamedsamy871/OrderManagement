using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Models.DomainModels;
using OrderManagement.Models.DTO;
using OrderManagement.Models.Enums;
using OrderManagement.Services;
using System;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DataContext _context;

        public OrdersController(DataContext context,ILoyalityService loyalityService)
        {
            _context = context;
        }
        [HttpGet("analytics")]
        [ProducesResponseType(typeof(OrderAnalyticsDto), 200)]
        public async Task<ActionResult<OrderAnalyticsDto>> GetOrderAnalytics()
        {
            var orders = await _context.Orders
                .Include(o => o.Customer)
                .Where(o => o.Status == OrderStatus.Delivered)
                .AsNoTracking()
                .ToListAsync();

            var averageValue = orders.Average(o => o.TotalAmount);
            var averageFulfillmentTime = orders
                .Average(o => (o.DeliveredAt - o.CreatedAt)?.TotalHours ?? 0);

            return Ok(new OrderAnalyticsDto
            {
                AverageOrderValue = averageValue,
                AverageFulfillmentTimeInHours = averageFulfillmentTime
            });
        }
    }
}
