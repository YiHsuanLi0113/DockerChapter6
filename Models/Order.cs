using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ManyToManyCodeFirst.Models;
public class Order
{
    //[Key]
    //ClassID 或ID 自動會產生Primary Key
    public short OrderId { get; set; }
 
    //using System.ComponentModel.DataAnnotations;
    [Required(ErrorMessage = "{0}不可空白")]
    [CheckOrderDate]
    public DateTime? OrderDate { get; set; }
   
    [Required(ErrorMessage = "{0}不可空白"),
    Range(1, 1000, ErrorMessage="運費需1~1000元的範圍")]
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
    //using System.Collections.Generic;
    public virtual List<OrderProduct> OrderProducts { get; set; }
    public Order(){
        OrderProducts = new List<OrderProduct>();
    }
}
