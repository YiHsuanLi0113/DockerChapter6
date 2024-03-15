using System.ComponentModel.DataAnnotations;


namespace ManyToManyCodeFirst.Models;
//using System.ComponentModel.DataAnnotations;
public class CheckSecurityID:ValidationAttribute
{
    public CheckSecurityID() {
        base.ErrorMessage = "這不是合法的身份證字號";
    }
    public override bool IsValid(object? value)
    {
        return CheckSID(value.ToString());
    }
    public bool CheckSID(string input)
    {
        //SecurityID驗證開始
        string number = input;


        int IntA = 0;
        int IntB = 0;
        int IntC = 0;


        if (number.Substring(0, 1).ToUpper() == "A")
        {
            IntA = 1;
            IntB = 0;
        }
        else if (number.Substring(0, 1).ToUpper() == "B")
        {
            IntA = 1;
            IntB = 1;
        }
        else if (number.Substring(0, 1).ToUpper() == "C")
        {
            IntA = 1;
            IntB = 2;
        }
        else if (number.Substring(0, 1).ToUpper() == "D")
        {
            IntA = 1;
            IntB = 3;
        }
        else if (number.Substring(0, 1).ToUpper() == "E")
        {
            IntA = 1;
            IntB = 4;
        }
        else if (number.Substring(0, 1).ToUpper() == "F")
        {
            IntA = 1;
            IntB = 5;
        }
        else if (number.Substring(0, 1).ToUpper() == "G")
        {
            IntA = 1;
            IntB = 6;
        }
        else if (number.Substring(0, 1).ToUpper() == "H")
        {
            IntA = 1;
            IntB = 7;
        }
        else if (number.Substring(0, 1).ToUpper() == "I")
        {
            IntA = 3;
            IntB = 4;
        }
        else if (number.Substring(0, 1).ToUpper() == "J")
        {
            IntA = 1;
            IntB = 8;
        }
        else if (number.Substring(0, 1).ToUpper() == "K")
        {
            IntA = 1;
            IntB = 9;
        }
        else if (number.Substring(0, 1).ToUpper() == "L")
        {
            IntA = 2;
            IntB = 0;
        }
        else if (number.Substring(0, 1).ToUpper() == "M")
        {
            IntA = 2;
            IntB = 1;
        }
        else if (number.Substring(0, 1).ToUpper() == "N")
        {
            IntA = 2;
            IntB = 2;
        }
        else if (number.Substring(0, 1).ToUpper() == "O")
        {
            IntA = 3;
            IntB = 5;
        }
        else if (number.Substring(0, 1).ToUpper() == "P")
        {
            IntA = 2;
            IntB = 3;
        }
        else if (number.Substring(0, 1).ToUpper() == "Q")
        {
            IntA = 2;
            IntB = 4;
        }
        else if (number.Substring(0, 1).ToUpper() == "R")
        {
            IntA = 2;
            IntB = 5;
        }
        else if (number.Substring(0, 1).ToUpper() == "S")
        {
            IntA = 2;
            IntB = 6;
        }
        else if (number.Substring(0, 1).ToUpper() == "T")
        {
            IntA = 2;
            IntB = 7;
        }
        else if (number.Substring(0, 1).ToUpper() == "U")
        {
            IntA = 2;
            IntB = 8;
        }
        else if (number.Substring(0, 1).ToUpper() == "V")
        {
            IntA = 2;
            IntB = 9;
        }
        else if (number.Substring(0, 1).ToUpper() == "W")
        {
            IntA = 3;
            IntB = 2;
        }
        else if (number.Substring(0, 1).ToUpper() == "X")
        {
            IntA = 3;
            IntB = 0;
        }
        else if (number.Substring(0, 1).ToUpper() == "Y")
        {
            IntA = 3;
            IntB = 1;
        }
        else if (number.Substring(0, 1).ToUpper() == "Z")
        {
            IntA = 3;
            IntB = 3;
        }


        int IntSum; //加總
        IntSum = IntA * 1 + IntB * 9 + System.Convert.ToInt32(number.Substring(1, 1)) * 8 + System.Convert.ToInt32(number.Substring(2, 1)) * 7 + System.Convert.ToInt32(number.Substring(3, 1)) * 6 + System.Convert.ToInt32(number.Substring(4, 1)) * 5 + System.Convert.ToInt32(number.Substring(5, 1)) * 4 + System.Convert.ToInt32(number.Substring(6, 1)) * 3 + System.Convert.ToInt32(number.Substring(7, 1)) * 2 + System.Convert.ToInt32(number.Substring(8, 1)) * 1;
        IntC = IntSum % 10; //餘數
        if (System.Convert.ToInt32(10 - IntC) != System.Convert.ToInt32(number.Substring(9, 1)) && System.Convert.ToInt32(10 - IntC) != 10)
        {
            return false;
        }
        else
        {
            return true;
        }
        //SecurityID驗證結束
    }
}
