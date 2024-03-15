using ManyToManyCodeFirst.Models;
using Microsoft.EntityFrameworkCore;


namespace ManyToManyCodeFirst.Data;
public class CustomerRepo : ICustomerRepo
{
    private readonly OrderContext _context;
    public CustomerRepo(OrderContext context)
    {
        _context = context;
    }


    public void CreateCustomer(Customer customer)
    {
        customer.CustomerIdGuid = Guid.NewGuid();  
        _context.Customers.Add(customer);
    }


    public void UpdateCustomer(Customer customer)
    {
        customer.CustomerIdGuid = Guid.NewGuid();
        _context.Customers.Update(customer);
    }


    public void DeleteCustomer(int id)
    {
         var customer = _context.Customers
                           .Where(m => m.CustomerId == id)
                           .FirstOrDefault();
        _context.Remove(customer);
    }


    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }


    public IEnumerable<Customer> GetAllCustomers()
    {
       return _context.Customers.ToList();
    }


    public Customer GetCustomerByGUID(Guid id)
    {
        var customer = _context.Customers
                    .Where(m => m.CustomerIdGuid == id)
                    .FirstOrDefault();
        return customer;
    }


    public Customer GetCustomerByID(int id)
    {
       var customer = _context.Customers
                    .Where(m => m.CustomerId == id)
                    .FirstOrDefault();
       return customer;
    }


    public Customer GetCustomerBySecurityID(string sid)
    {
        var customer = _context.Customers
                    .Where(m => m.SecurityID == sid)
                    .FirstOrDefault();
        return customer;
    }


    public IEnumerable<OrderDetailViewModel> GetCustomerOrderByGUID(Guid id)
    {
        var order =  _context.OrderProducts
            .Include(o => o.Order)
            .Include(o => o.Order.Customer)
            .Include(p => p.Product)
            .Where(o => o.Order.Customer.CustomerIdGuid == id)
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
