using System.ComponentModel.DataAnnotations;

namespace DIMS_Core.Common.Attributes
{
    /// <summary>
    /// TODO: Task #5 
    /// Create validation attribute for password
    /// using regular expressions
    /// rules: min length 6 symbols, at least 2 upper case letters, at least 2 lower case letters
    /// </summary>
    public class PasswordValidationAttribute : ValidationAttribute
    {
    }
}
