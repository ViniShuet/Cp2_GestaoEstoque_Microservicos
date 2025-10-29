namespace Domain
{
    public class Produto
    {
        public int CodigoSKU { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; } //perecivel ou nao (boolean)
        public int PrecoUnitario { get; set; }
        public int QtdMin { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
