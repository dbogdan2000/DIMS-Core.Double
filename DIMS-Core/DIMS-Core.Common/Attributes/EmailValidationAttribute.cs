using System.ComponentModel.DataAnnotations;

namespace DIMS_Core.Common.Attributes
{
    /// <summary>
    ///     TODO: Task #6
    ///     Create validation attribute for email
    ///     rule: min 3 letters in the beggining, only one @ in the center, at least 2 letters after @,
    ///     don't forget to add domain rule at the end, for example .com, .by, .info - are valid domains
    /// </summary>
    public class EmailValidationAttribute : ValidationAttribute
    {
    }
}