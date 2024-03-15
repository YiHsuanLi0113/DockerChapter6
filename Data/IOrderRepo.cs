using ManyToManyCodeFirst.Models;


namespace ManyToManyCodeFirst.Data;
public interface IOrderRepo
{
    void NewOrder(Order order);
    void UpdateOrder(Order order);
    void DeleteOrder(Order order);
    bool SaveChanges();
    IEnumerable<Order> GetAllOrders();
    Order GetOrderById(int id);
    IEnumerable<OrderDetailViewModel> GetOrderDetailById(int id);
    IEnumerable<OrderDetailViewModel> GetOrderByCustomerIdOrderDate(int customerid, string orderdate);
    IEnumerable<OrderDetailViewModel> GetOrderByCustomerNameOrderDate(string customername, string orderdate);
}
