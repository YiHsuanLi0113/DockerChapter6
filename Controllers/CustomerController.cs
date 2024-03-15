using ManyToManyCodeFirst.Data;
using ManyToManyCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ManyToManyCodeFirst.Controllers;
//using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomerRepo _repository;
    private readonly IConfiguration _config;
    public CustomersController(ICustomerRepo repository, IConfiguration config)
    {
        _repository = repository;
        _config = config;
    }


    // GET: api/Customers
    [HttpGet]
    public ActionResult<IEnumerable<Customer>> GetCustomers()
    {
        if (!_repository.GetAllCustomers().Any())
        {
            return NotFound();
        }
        var customers = _repository.GetAllCustomers();
        foreach (Customer item in customers)
        {
        string pattern = @"\d{5}$";
        string replacement = "xxxxx";
        string input = item.SecurityID;
        //using System.Text.RegularExpressions;
        item.SecurityID=Regex.Replace(input, pattern, replacement);
        }
        return Ok(customers);
    }


    // GET: api/Customers/5
    [HttpGet("{id}")]
    public ActionResult<Customer> GetCustomer(int id)
    {
        if (!_repository.GetAllCustomers().Any())
        {
            return NotFound();
        }
        var customer = _repository.GetCustomerByID(id);


        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }


    // PUT: api/Customers/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public IActionResult PutCustomer(int id, Customer customer)
    {
        if (id != customer.CustomerId)
        {
            return BadRequest();
        }
        _repository.UpdateCustomer(customer);  


        try
        {
            _repository.SaveChanges();  
        }
        catch (DbUpdateConcurrencyException)
        {
            if (_repository.GetCustomerByID(id)==null)
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


    // POST: api/Customers
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public ActionResult<Customer> PostCustomer(Customer customer)
    {
        if (!_repository.GetAllCustomers().Any())
        {
            return NotFound();
        }
        _repository.CreateCustomer(customer);
        _repository.SaveChanges();
        return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
    }


    // DELETE: api/Customers/5
    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        if (!_repository.GetAllCustomers().Any())
        {
            return NotFound();
        }
        var customer=_repository.GetCustomerByID(id);
        if (customer == null)
        {
            return NotFound();
        }
        _repository.DeleteCustomer(id);
        _repository.SaveChanges();  
        return NoContent();
    }


    // GET: api/Customers/GUID/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
    [HttpGet("GUID/{id:guid}")]
    public ActionResult<Customer> GetCustomerbyGUID(Guid id)
    {
        var customer = _repository.GetCustomerByGUID(id);
        if (customer == null)
        {
            return NotFound();
        }
        return customer;
    }


    // GET: api/Customers/SID/A123456789
    // ^[A-Za-z][12]\d{8}$
    [HttpGet("SID/{sid:regex(^[[A-Za-z]][[12]]\\d{{8}}$)}")]
    public async Task<ActionResult<Customer>> GetCustomerSID(string sid)
    {
        var customer = _repository.GetCustomerBySecurityID(sid);
        if (customer == null)
        {
            return NotFound();
        }
        return customer;
    }


    // GET: api/Customers/ListOrder/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
    [HttpGet("ListOrder/{id:guid}")]
    public ActionResult<IEnumerable<OrderDetailViewModel>> GetCustomerOrderbyGUID(Guid id)
    {
       
        var order=_repository.GetCustomerOrderByGUID(id);  
        if (order == null)
        {
            return NotFound();
        }
        else {
            return Ok(order);
        }
    }


    [HttpGet("sql/{companyname}")]
    public IActionResult JsonBySQL(string companyname)
    {
        //using System.Data.SqlClient;
        var cn = new SqlConnection(_config.GetConnectionString("DefaultConnection2"));
        var cmd = cn.CreateCommand();//SqlCommand
        cmd.CommandText ="Select C.CustomerId,C.CompanyName,O.OrderId,O.OrderDate,P.ProductId,P.ProductName,OP.Quantity,OP.UnitPrice,OP.Discount " +
                            "From [dbo].[Customers] C join [dbo].[Orders] O "+
                            "on C.CustomerId=O.CustomerId " +
                            "join [dbo].[OrderProducts] OP " +
                            "on O.OrderId=OP.OrderId " +
                            "join [dbo].[Products] P " +
                            "on P.ProductId=OP.ProductId " +
                            "where C.CompanyName=@CompanyName";
        cmd.Parameters.AddWithValue("@CompanyName",companyname);
        cn.Open();
        //using System.Data;
        var dr = cmd.ExecuteReader();//SqlDataReader
        //using System.Collections;
        ArrayList list = new ArrayList();
        while (dr.Read())
        {
            var data = new
            {
                CustomerId = dr["CustomerId"].ToString(),
                CompanyName = dr["CompanyName"].ToString(),
                OrderId = dr["OrderId"].ToString(),
                OrderDate = Convert.ToDateTime(dr["OrderDate"]).ToString("d"),
                ProductId = dr["ProductId"].ToString(),
                ProductName = dr["ProductName"].ToString(),
                UnitPrice=dr["UnitPrice"].ToString(),
                Quantity =dr["Quantity"].ToString(),
                Discount = dr["Discount"].ToString()
            };
            list.Add(data);
        }
        dr.Close();
        cn.Close();
        return Ok(list);          
    }
   
    [HttpGet("{login:alpha}/{password:length(8,20)}/{sid:regex(^[[A-Za-z]][[12]]\\d{{8}}$)}")]
    public ActionResult<string> Get(string login,string password,string sid)
    {
        return ($"您登入帳號是:{login},密碼是:{password},身份證:{sid}");
    }

}
