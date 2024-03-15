namespace ManyToManyCodeFirst.Models;
public class Order
{
    public short OrderId { get; set; }
    public DateTime? OrderDate { get; set; }
    public float? Freight { get; set; }
}
