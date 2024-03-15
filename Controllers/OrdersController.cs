using ManyToManyCodeFirst.Data;
using ManyToManyCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ManyToManyCodeFirst.Controllers;
//using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderRepo _repository;
    private readonly IProductRepo _productrepo;
    public OrdersController(IOrderRepo repository,IProductRepo productrepo)
    {
            _repository = repository;
            _productrepo = productrepo;
    }
    // GET: api/Orders
    [HttpGet]
    public ActionResult<IEnumerable<Order>> GetOrders()
    {
        if (!_repository.GetAllOrders().Any())
        {
            return NotFound();
        }
        var orders = _repository.GetAllOrders();
        return Ok(orders);
    }
    // GET: api/Orders/5
    [HttpGet("{id}")]
    public  ActionResult<IEnumerable<OrderDetailViewModel>> GetOrder(short id)
    {
        var order=_repository.GetOrderDetailById(id);  
        if (order == null)
        {
            return NotFound();
        }
        else {
            return Ok(order);
        }
    }
    // PUT: api/Orders/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutOrder(short id, Order order)
    {
        if (id != order.OrderId)
        {
            return BadRequest();
        }
        //Controller Validation->依存性驗證
        foreach (var item in order.OrderProducts)
        {
            //訂單產品售價需與產品訂價符合
            if ( _productrepo.GetUnitPriceByProductId(item.ProductId)!=item.UnitPrice)
            {
                return BadRequest();
            }
        }


        _repository.UpdateOrder(order);


        try
        {
            _repository.SaveChanges();  
        }
        catch (DbUpdateConcurrencyException)
        {
            if (_repository.GetOrderById(id)==null)
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }
    // POST: api/Orders
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public ActionResult<Order> PostOrder(Order order)
    {
        if (!_repository.GetAllOrders().Any())
        {
            return NotFound();
        }
        _repository.NewOrder(order);
        _repository.SaveChanges();    
        return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
    }
    // DELETE: api/Orders/5
    [HttpDelete("{id}")]
    public IActionResult DeleteOrder(short id)
    {
        if (!_repository.GetAllOrders().Any())
        {
            return NotFound();
        }
        var order = _repository.GetOrderById(id);  
        if (order == null)
        {
            return NotFound();
        }
        _repository.DeleteOrder(order);
        _repository.SaveChanges();
        return NoContent();
    }
    // GET: api/Orders/query?customerid=1&orderdate=2022/1/1
    [HttpGet("/query")]
    public ActionResult<IEnumerable<OrderDetailViewModel>> GetCustomerOrderByID([FromQuery] int customerid, [FromQuery] string orderdate)
    {
        var orders =_repository.GetOrderByCustomerIdOrderDate(customerid,orderdate);
        if (orders == null)
        {
            return NotFound();
        }
        else {
            return Ok(orders);
        }
    }
    //GET: api/Orders/query2?customername=Micrisoft&orderdate=2022/1/1
    [HttpGet("/query2")]
    public ActionResult<IEnumerable<OrderDetailViewModel>> GetCustomerOrderByName([FromQuery] string customername, [FromQuery] string orderdate)
    {
        var orders =_repository.GetOrderByCustomerNameOrderDate(customername,orderdate);
        if (orders == null)
        {
            return NotFound();
        }
        else {
            return Ok(orders);
        }
    }
}
