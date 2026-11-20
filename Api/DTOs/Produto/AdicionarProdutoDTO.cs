using System.ComponentModel.DataAnnotations;

namespace Api.DTOs.Produto
{
    public class AdicionarProdutoDTO
    {

        [Required]
        public string NomeProduto { get; set; }

        public string Descricao { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        public int Estoque { get; set; }

        public decimal TotalValor { get; set; }

    }
}
