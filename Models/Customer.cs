using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ManyToManyCodeFirst.Models;
public class Customer
{
    //using System.ComponentModel.DataAnnotations;
    [Key]
    //ClassNameID 或ID 自動會產生Primary Key
    public int CustomerId { get; set; }

    //public Guid CustomerIdGuid { get; set; }
    //xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
    private Guid customerIdGuid;
    public Guid CustomerIdGuid
    {
        get => customerIdGuid;
        set => customerIdGuid = Guid.NewGuid();
    }


    //using System.ComponentModel.DataAnnotations.Schema;
    [Column(TypeName = "nvarchar(50)")]
    [MinLength(3, ErrorMessage = "{0}至少需要{1}字數"),
     MaxLength(50, ErrorMessage = "{0}不可超過{1}字數")]
    [Required(ErrorMessage = "{0}不可空白")]
    public string CompanyName { get; set; }
   
    [Column(TypeName = "nvarchar(20)"),
    MinLength(8, ErrorMessage = "{0}至少需要{1}字數"),
    MaxLength(20, ErrorMessage = "{0}不可超過{1}字數"),
    Required(ErrorMessage = "{0}不可空白")]
    public string LoginName { get; set; }


    [Column(TypeName = "char(10)"),
    Required(ErrorMessage = "{0}不可空白"),
    RegularExpression(@"^[A-Za-z][12]\d{8}$", ErrorMessage = "身份證字號格式不正確")]
    [CheckSecurityID]
    public string SecurityID { get; set; }


    [Required(ErrorMessage = "{0}不可空白"),
    EmailAddress(ErrorMessage = "EMAIL格式不正確")]
    public string Email { get; set; }
    //1對多
    //設定多
    public virtual List<Order> Orders { get; set; }
    public Customer() {
        Orders = new List<Order>();
    }
}
