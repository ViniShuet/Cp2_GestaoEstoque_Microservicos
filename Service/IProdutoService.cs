using Domain;
using System.Threading.Tasks;

namespace Service
{
    public interface IProdutoService
    {
        Task<int> CadastrarProdutoAsync(Produto produto);
        void VerificaEstoqueMinimo(Produto produto);
    }
}
