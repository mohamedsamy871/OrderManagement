using OrderManagement.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.Models.DomainModels
{
    public class Order
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public OrderStatus Status { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = new();
    }
}
