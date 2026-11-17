using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
    public class AdicionarProdutoDTO
    {

        [Required]
        public string NomeProduto { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        public int Estoque { get; set; }

        [Required]
        public decimal TotalValor { get; set; }


        public AdicionarProdutoDTO()
        {
            TotalValor = Preco * Estoque;
        }
    }
}
