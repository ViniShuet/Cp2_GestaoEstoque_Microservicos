using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProdutoRepository
    {
        Task<int> AddAsync(Produto produto);
        Task AtualizarAsync(Produto produto);
        Task<Produto?> ObterPorIdAsync(int id);
        Task<IEnumerable<Produto>> ObterTodosAsync();
    }
}
