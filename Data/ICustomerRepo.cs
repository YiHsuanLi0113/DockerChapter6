using ManyToManyCodeFirst.Models;


namespace ManyToManyCodeFirst.Data;
public interface ICustomerRepo
{   
    void CreateCustomer(Customer customer);
    void UpdateCustomer(Customer customer);
    void DeleteCustomer(int id);
    bool SaveChanges();


    IEnumerable<Customer> GetAllCustomers();
    Customer GetCustomerByGUID(Guid id);
    Customer GetCustomerByID(int id);
    Customer GetCustomerBySecurityID(string sid);
    IEnumerable<OrderDetailViewModel> GetCustomerOrderByGUID(Guid id);
}
