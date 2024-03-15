using ManyToManyCodeFirst.Models;
using Microsoft.EntityFrameworkCore;


namespace ManyToManyCodeFirst.Data;
public class OrderRepo : IOrderRepo
{
    private readonly OrderContext _context;


    public OrderRepo(OrderContext context)
    {
        _context = context;
    }
    public void NewOrder(Order order)
    {
        _context.Orders.Add(order);
    }
    public void UpdateOrder(Order order)
    {
        _context.Orders.Update(order);
    }
    public void DeleteOrder(Order order)
    {
       var delorder=_context.Orders.Find(order.OrderId);
       _context.Orders.Remove(delorder);


    }
    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }


    public IEnumerable<Order> GetAllOrders()
    {
        return _context.Orders.ToList();
    }


    public Order GetOrderById(int id)
    {
         return _context.Orders.FirstOrDefault(p => p.OrderId == id);
    }


    public IEnumerable<OrderDetailViewModel> GetOrderDetailById(int id)
    {
        var order =  _context.OrderProducts
            .Include(o => o.Order)
            .Include(p => p.Product)
            .Where(m => m.OrderId == id)
            .Select(b => new OrderDetailViewModel
            {
                OrderId = b.Order.OrderId,
                OrderDate = b.Order.OrderDate,
                Freight = b.Order.Freight,
                ProductId = b.ProductId,
                ProductName = b.Product.ProductName,
                UnitPrice = b.UnitPrice,
                Quantity = b.Quantity,
                Discount = b.Discount
            }).ToList();
        return order;
    }
    public IEnumerable<OrderDetailViewModel> GetOrderByCustomerIdOrderDate(int customerid, string orderdate)
    {
        var order = _context.OrderProducts
                .Include(o => o.Order)
                .Include(p => p.Product)
                .Where(m => m.Order.CustomerId == customerid && m.Order.OrderDate >= DateTime.Parse(orderdate))
                .Select(b => new OrderDetailViewModel
                {
                    OrderId = b.Order.OrderId,
                    OrderDate = b.Order.OrderDate,
                    Freight = b.Order.Freight,
                    ProductId = b.ProductId,
                    ProductName = b.Product.ProductName,
                    UnitPrice = b.UnitPrice,
                    Quantity = b.Quantity,
                    Discount = b.Discount
                }).ToList();
        return order;
    }
    public IEnumerable<OrderDetailViewModel> GetOrderByCustomerNameOrderDate(string customername, string orderdate)
    {
        var order =  _context.OrderProducts
                .Include(o => o.Order)
                .Include(p => p.Product)
                .Where(m => m.Order.Customer.CompanyName == customername && m.Order.OrderDate >= DateTime.Parse(orderdate))
                .Select(b => new OrderDetailViewModel
                {
                    OrderId = b.Order.OrderId,
                    OrderDate = b.Order.OrderDate,
                    Freight = b.Order.Freight,
                    ProductId = b.ProductId,
                    ProductName = b.Product.ProductName,
                    UnitPrice = b.UnitPrice,
                    Quantity = b.Quantity,
                    Discount = b.Discount
                }).ToList();
        return order;
    }
}
