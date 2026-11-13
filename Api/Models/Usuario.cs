using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Api.Atributte;

namespace Api.Models
{
    public class Usuario
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 20 caracteres")]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Senha { get; set; }
    }
}
