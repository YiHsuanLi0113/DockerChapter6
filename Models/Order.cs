using System.ComponentModel.DataAnnotations.Schema;


namespace ManyToManyCodeFirst.Models;
public class Order
{
    //[Key]
    //ClassID 或ID 自動會產生Primary Key
    public short OrderId { get; set; }
    public DateTime? OrderDate { get; set; }
    public float? Freight { get; set; }
    //1對多
    //Foreign Key
    //預設跟Primary Key同名
    //using System.ComponentModel.DataAnnotations.Schema;
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    //設定1      
    public virtual Customer? Customer { get; set; }


    //1對多
    //設定多
    public virtual List<OrderProduct> OrderProducts { get; set; }
    public Order(){
        OrderProducts = new List<OrderProduct>();
    }
}
