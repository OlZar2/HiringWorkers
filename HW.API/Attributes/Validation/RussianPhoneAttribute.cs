using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace HW.API.Attributes.Validation;

public class RussianPhoneAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value == null) return false;
        var phone = value.ToString();

        return Regex.IsMatch(phone, @"^(?:\+7|8)\d{10}$");
    }
}
