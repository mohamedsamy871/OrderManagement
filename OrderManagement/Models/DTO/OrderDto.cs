using OrderManagement.Models.Enums;

namespace OrderManagement.Models.DTO
{
    public class OrderDto
    {
        public CustomerSegment CustomerSegment { get; set; }
        public decimal OrderTotal { get; set; }
    }
}
