namespace Domain
{
    public class MovEstoque
    {
        public int ProdutoId { get; set; }
        public string Tipo { get; set; } 
        public int Qtd { get; set; }
        public DateTime DataMov { get; set; } = DateTime.Now;
    }
}
