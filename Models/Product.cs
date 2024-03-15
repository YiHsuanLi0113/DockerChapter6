namespace ManyToManyCodeFirst.Models;
public class Product
{
    public short ProductId { get; set; }
    public string ProductName { get; set; }
    public float UnitPrice { get; set; }


    //1對多
    //設定多
    public virtual List<OrderProduct> OrderProducts { get; set; }
    public Product(){
        OrderProducts = new List<OrderProduct>();
    }
}
