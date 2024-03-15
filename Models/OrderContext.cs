using Microsoft.EntityFrameworkCore;


namespace ManyToManyCodeFirst.Models;
//using Microsoft.EntityFrameworkCore;
public class OrderContext : DbContext
{
    public OrderContext(DbContextOptions<OrderContext> options) : base(options) {
    }
   
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<OrderProduct> OrderProducts { get; set; }
    public virtual DbSet<Product> Products { get; set; }
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //多對多Junction Table 複合主鍵
        modelBuilder.Entity<OrderProduct>().HasKey(table => new {
            table.OrderId,
            table.ProductId
        });
        //初始值
        modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                CustomerId = 1,
                CompanyName = "Microsoft",
                LoginName="microsoft",
                SecurityID="A123456789",
                Email="microsoft@test.com"
            },
            new Customer
            {
                CustomerId = 2,
                CompanyName = "Amazon",
                LoginName = "amazon",
                SecurityID = "A123456798",
                Email = "amazon@test.com"
            },
            new Customer
            {
                CustomerId = 3,
                CompanyName = "Google",
                LoginName = "google",
                SecurityID = "A123456789",
                Email = "google@test.com"
            }
        );
         
        modelBuilder.Entity<Order>().HasData(
            new Order
            {
                OrderId = 1,
                CustomerId = 1,
                OrderDate = new DateTime(2022, 1, 1),
                Freight = 80
            },
            new Order
            {
                OrderId = 2,
                CustomerId = 2,
                OrderDate = new DateTime(2022, 2, 1),
                Freight = 80
            },
            new Order
            {
                OrderId = 3,
                CustomerId = 3,
                OrderDate = new DateTime(2022, 3, 1),
                Freight = 80
            },
            new Order
            {
                OrderId = 4,
                CustomerId = 1,
                OrderDate = new DateTime(2022, 4, 1),
                Freight = 80
            }
        );
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                ProductId = 1,
                ProductName = "iPhone",
                UnitPrice = 30000
            },
            new Product
            {
                ProductId = 2,
                ProductName = "iMac",
                UnitPrice = 50000
            },
            new Product
            {
                ProductId = 3,
                ProductName = "iPad",
                UnitPrice = 20000
            }
        );
        modelBuilder.Entity<OrderProduct>().HasData(
            new OrderProduct
            {
                OrderId = 1,
                ProductId = 1,
                UnitPrice = 30000,
                Quantity = 1,
                Discount = 0.10f
            },
            new OrderProduct
            {
                OrderId = 1,
                ProductId = 3,
                UnitPrice = 50000,
                Quantity = 1,
                Discount = 0.10f
            },
            new OrderProduct
            {
                OrderId = 2,
                ProductId = 2,
                UnitPrice = 20000,
                Quantity = 1,
                Discount = 0
            },
            new OrderProduct
            {
                OrderId = 3,
                ProductId = 1,
                UnitPrice = 29000,
                Quantity = 2,
                Discount = 0
            },
            new OrderProduct
            {
                OrderId = 4,
                ProductId = 2,
                UnitPrice = 50000,
                Quantity = 1,
                Discount = 0.15f
            },
            new OrderProduct
            {
                OrderId = 4,
                ProductId = 3,
                UnitPrice = 20000,
                Quantity = 1,
                Discount = 0.15f
            }
        );
    }
}
