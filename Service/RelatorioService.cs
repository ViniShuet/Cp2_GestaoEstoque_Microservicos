using Domain;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IProdutoRepository _repository;

        public RelatorioService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<decimal> CalcularValorTotalAsync()
        {
            var produtos = await _repository.ObterTodosAsync();
            return produtos.Sum(p => p.EstoqueAtual * p.PrecoUnitario);
        }

        public async Task<IEnumerable<Produto>> VencendoEm7DiasAsync()
        {
            var produtos = await _repository.ObterTodosAsync();
            var limite = DateTime.Today.AddDays(7);
            return produtos.Where(p => p.Perecivel && p.DataValidade.HasValue && p.DataValidade.Value <= limite);
        }

        public async Task<IEnumerable<Produto>> AbaixoDoMinimoAsync()
        {
            var produtos = await _repository.ObterTodosAsync();
            return produtos.Where(p => p.EstoqueAtual < p.QtdMin);
        }
    }
}
