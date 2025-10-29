namespace Domain
{
    public class Produto
    {
        public int CodigoSKU { get; set; }
        public string Nome { get; set; }
        public bool Perecivel { get; set; } 
        public decimal PrecoUnitario { get; set; }
        public int EstoqueAtual { get; set; }
        public int QtdMin { get; set; }
        public DateTime? DataValidade { get; set; } 
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
