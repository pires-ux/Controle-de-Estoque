

using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Api.Atributte
{
    class NaoTemNumero : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            while (value is string strValue)
            {
                if (strValue.Any(char.IsDigit))
                {
                    return new ValidationResult("O campo não pode conter números.");
                }
                break;
            }

            return ValidationResult.Success!;
        }
    }
}
