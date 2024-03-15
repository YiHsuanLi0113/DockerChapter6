using System.ComponentModel.DataAnnotations;


namespace ManyToManyCodeFirst.Models;
public class Customer
{
    //using System.ComponentModel.DataAnnotations;
    [Key]
    //ClassNameID 或ID 自動會產生Primary Key
    public int CustomerId { get; set; }
    public string CompanyName { get; set; }
    public string LoginName { get; set; }
    public string SecurityID { get; set; }
    public string Email { get; set; }
    //1對多
    //設定多
    public virtual List<Order> Orders { get; set; }
    public Customer() {
        Orders = new List<Order>();
    }
}
