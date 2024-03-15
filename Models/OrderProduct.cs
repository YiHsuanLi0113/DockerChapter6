using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ManyToManyCodeFirst.Models;
//Junction Table
public class OrderProduct
{
    //1.由外鍵組成的複合主鍵
    //using System.ComponentModel.DataAnnotations;
    //using System.ComponentModel.DataAnnotations.Schema;
    [Key,Column(Order=1)]
    [ForeignKey("Order")]
    public short OrderId { get; set; }
    [Key, Column(Order = 2)]
    [ForeignKey("Product")]
    public short ProductId { get; set; }


    //2.多對多行為屬性
    [Required(ErrorMessage = "{0}不可空白"),
    Range(1, 100000, ErrorMessage = "售價需1~100000元的範圍")]
    public float UnitPrice { get; set; }
   
    [Required(ErrorMessage = "{0}不可空白"),
    Range(1, 100, ErrorMessage = "訂購數量需1~100的範圍內")]
    public short Quantity { get; set; }
    public float Discount { get; set; }


    //設定1      
    public virtual Order? Order { get; set; }
    public virtual Product? Product { get; set; }
}
