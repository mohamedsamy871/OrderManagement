using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;

namespace OrderManagement.Models.DomainModels
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
