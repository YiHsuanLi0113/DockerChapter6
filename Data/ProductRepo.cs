using ManyToManyCodeFirst.Models;
using Microsoft.EntityFrameworkCore;


namespace ManyToManyCodeFirst.Data;
public class ProductRepo:IProductRepo
{
    private readonly OrderContext _context;


    public ProductRepo(OrderContext context)
    {
        _context = context;
    }
    public void CreateProduct(Product product)
    {
        _context.Products.Add(product);
    }
    public void UpdateProduct(Product product)
    {
        _context.Products.Update(product);
    }
    public void DeleteProduct(Product product)
    {
       var delproduct=_context.Products.Find(product.ProductId);
       _context.Products.Remove(delproduct);
    }


    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }


    public IEnumerable<Product> GetAllProducts()
    {
        return _context.Products.ToList();
    }
    public Product GetProductById(int id)
    {
         return _context.Products.FirstOrDefault(p => p.ProductId == id);
    }


    public double GetUnitPriceByProductId(int id)
    {
        return _context.Products
            .Where(p => p.ProductId == id)
            .Select(b =>  b.UnitPrice).FirstOrDefault();    
    }
}
