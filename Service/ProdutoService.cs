using Domain;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CadastrarProdutoAsync(Produto produto)
        {

            if (!produto.Perecivel && produto.DataValidade.HasValue)
                throw new Exception("Produto não perecível não deve ter data de validade.");

            if (produto.PrecoUnitario <= 0)
                throw new Exception("Preço unitário deve ser maior que zero.");

            if (string.IsNullOrWhiteSpace(produto.Nome))
                throw new Exception("Nome do produto é obrigatório.");

            int id = await _repository.AddAsync(produto);
            VerificaEstoqueMinimo(produto);
            return id;
        }

        public void VerificaEstoqueMinimo(Produto produto)
        {
            const int limite = 10;
            if (produto.QtdMin < limite)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($" Produto '{produto.Nome}' está abaixo do limite mínimo ({produto.QtdMin} < {limite})");
                Console.ResetColor();
            }
        }
        public async Task<Produto> ObterPorIdAsync(int id)
        {
            return await _repository.ObterPorIdAsync(id);
        }

        public async Task<IEnumerable<Produto>> ListarProdutosAbaixoDoMinimoAsync()
        {
            var todos = await _repository.ObterTodosAsync();
            return todos.Where(p => p.EstoqueAtual < p.QtdMin);
        }

    }
}

