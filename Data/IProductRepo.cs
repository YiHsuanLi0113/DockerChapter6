using ManyToManyCodeFirst.Models;
namespace ManyToManyCodeFirst.Data;
public interface IProductRepo
{
    void CreateProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
    bool SaveChanges();
    IEnumerable<Product> GetAllProducts();
    Product GetProductById(int id);
    double GetUnitPriceByProductId(int id);
}
