using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        public string ProdutoNome { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public decimal TotalValor { get; set; }
    }
}
