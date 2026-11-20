using System.ComponentModel.DataAnnotations;

namespace Api.DTOs.Produto
{
    public class ResponseDTO
    {
        public string ProdutoNome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal TotalValor { get; set; }
    }
}
