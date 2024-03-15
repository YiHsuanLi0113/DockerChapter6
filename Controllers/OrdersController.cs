using ManyToManyCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ManyToManyCodeFirst.Controllers;
//using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    //using ManyToManyCodeFirst.Models;
    private readonly OrderContext _context;
    public OrdersController(OrderContext context)
    {
        _context = context;
    }
     [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        if (_context.Orders == null)
        {
            return NotFound();
        }
        //using Microsoft.EntityFrameworkCore;
        return await _context.Orders.ToListAsync();
    }
    [HttpPost]
    public async Task<ActionResult<Order>> PostOrder(Order order)
    {
        if (_context.Orders == null)
        {
            return Problem("Entity set 'OrderContext.Orders'  is null.");
        }
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();


        return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(short id)
    {
        if (_context.Orders == null)
        {
            return NotFound();
        }
        var order = await _context.Orders.FindAsync(id);
        if (order == null)
        {
            return NotFound();
        }
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();


        return NoContent();
    }
    private bool OrderExists(short id)
    {
        return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
    }
}
