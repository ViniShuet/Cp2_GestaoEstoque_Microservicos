using Domain;
using Repository;
using System;
using System.Threading.Tasks;

namespace Service
{
    public class MovimentacaoService : IMovimentacaoService
    {
        private readonly IProdutoRepository _repository;

        public MovimentacaoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public void ValidarDataPerecivel(Produto produto)
        {
            if (produto.Perecivel && produto.DataValidade.HasValue && produto.DataValidade.Value < DateTime.Today)
                throw new Exception($"Produto '{produto.Nome}' está vencido (validade: {produto.DataValidade.Value:dd/MM/yyyy})");
        }

        public async Task RealizarEntradaAsync(MovEstoque mov)
        {
            if (mov.Qtd <= 0)
                throw new Exception("Quantidade deve ser positiva.");

            var produto = await _repository.ObterPorIdAsync(mov.ProdutoId)
                          ?? throw new Exception("Produto não encontrado.");

            produto.EstoqueAtual += mov.Qtd;
            await _repository.AtualizarAsync(produto);
            Console.WriteLine($"✅ Entrada registrada. Estoque: {produto.EstoqueAtual}");
        }

        public async Task RealizarSaidaAsync(MovEstoque mov)
        {
            if (mov.Qtd <= 0)
                throw new Exception("Quantidade deve ser positiva.");

            var produto = await _repository.ObterPorIdAsync(mov.ProdutoId)
                          ?? throw new Exception("Produto não encontrado.");

            if (produto.EstoqueAtual < mov.Qtd)
                throw new Exception($"Estoque insuficiente. Atual: {produto.EstoqueAtual}");

            produto.EstoqueAtual -= mov.Qtd;
            await _repository.AtualizarAsync(produto);

            Console.WriteLine($"✅ Saída registrada. Novo estoque: {produto.EstoqueAtual}");
        }
    }
}
