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
                throw new Exception("Impossivel de realizar a entrada");
        }

        public async Task RealizarEntradaAsync(MovEstoque mov)
        {
            if (mov.Qtd <= 0)
                throw new Exception("Impossivel de realizar a entrada com quantidade menor ou igual a 0");

            var produto = await _repository.ObterPorIdAsync(mov.ProdutoId)
                          ?? throw new Exception("Produto não encontrado.");

            ValidarDataPerecivel(produto);

            produto.EstoqueAtual += mov.Qtd;
            await _repository.AtualizarAsync(produto);
            if (produto.EstoqueAtual < produto.QtdMin)
                Console.WriteLine($" Atenção: Estoque do produto '{produto.Nome}' abaixo do mínimo ({produto.EstoqueAtual} < {produto.QtdMin})");
            Console.WriteLine($" Entrada registrada. Estoque: {produto.EstoqueAtual}");
        }

        public async Task RealizarSaidaAsync(MovEstoque mov)
        {
            if (mov.Qtd <= 0)
                throw new Exception("Impossivel de realizar a saida com quantidade menor ou igual a 0");

            var produto = await _repository.ObterPorIdAsync(mov.ProdutoId)
                          ?? throw new Exception("Produto não encontrado.");

            ValidarDataPerecivel(produto);

            if (produto.EstoqueAtual < mov.Qtd)
                throw new Exception("Impossivel de realizar a saida com estoque atual menor que a quantidade");

            produto.EstoqueAtual -= mov.Qtd;
            await _repository.AtualizarAsync(produto);

            if (produto.EstoqueAtual < produto.QtdMin)
                Console.WriteLine($" Atenção: Estoque do produto '{produto.Nome}' abaixo do mínimo ({produto.EstoqueAtual} < {produto.QtdMin})");
            Console.WriteLine($" Saída registrada. Novo estoque: {produto.EstoqueAtual}");
        }
    }
}
