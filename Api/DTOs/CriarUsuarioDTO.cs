using Api.Atributte;
using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
    public class CriarUsuarioDTO
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 20 caracteres")]
        [NaoTemNumero]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 30 caracteres")]
        public string Senha { get; set; }
    }
}
