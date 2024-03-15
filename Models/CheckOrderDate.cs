using System.ComponentModel.DataAnnotations;


namespace ManyToManyCodeFirst.Models;
//using System.ComponentModel.DataAnnotations;
public class CheckOrderDate : ValidationAttribute
{
    public CheckOrderDate(){
        base.ErrorMessage="訂購日期需一年內,且不能大於今天";
    }
    public override bool IsValid(object? value)
    {
        return CheckDate(Convert.ToDateTime(value));
    }
    public bool CheckDate(DateTime input)
    {
        if (input>=DateTime.Today.AddYears(-1) && input<=DateTime.Today) {
            return true;
        }
        else {
            return false;
        }
    }
}
