using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ManyToManyCodeFirst.Models;
public class Product
{
    public short ProductId { get; set; }
    //using System.ComponentModel.DataAnnotations;
    //using System.ComponentModel.DataAnnotations.Schema;
    [Column(TypeName = "nvarchar(50)"),
    MinLength(3, ErrorMessage = "{0}至少需要{1}字數"),
    MaxLength(50, ErrorMessage = "{0}不可超過{1}字數"),
    Required(ErrorMessage = "{0}不可空白")]
    public string ProductName { get; set; }
    
    [Required(ErrorMessage = "{0}不可空白"),
    Range(1, 100000, ErrorMessage = "訂價需1~100000元的範圍")]
    public float UnitPrice { get; set; }


    //1對多
    //設定多
    public virtual List<OrderProduct> OrderProducts { get; set; }
    public Product(){
        OrderProducts = new List<OrderProduct>();
    }
}


