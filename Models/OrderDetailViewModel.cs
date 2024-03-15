using System.ComponentModel.DataAnnotations.Schema;


namespace ManyToManyCodeFirst.Models;
//using System.ComponentModel.DataAnnotations.Schema;
[NotMapped]
public class OrderDetailViewModel
{
    public short OrderId { get; set; }
    public DateTime? OrderDate { get; set; }
    public float? Freight { get; set; }
    public short  ProductId{ get; set; }
    public string ProductName { get; set; }
    public float UnitPrice { get; set; }
    public short Quantity { get; set; }
    public float Discount { get; set; }
}
