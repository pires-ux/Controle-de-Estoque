namespace Api.DTOs.Produto
{
    public class EditProdutoDTO
    {

        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public int TotalValor { get; set; }

    }
}
