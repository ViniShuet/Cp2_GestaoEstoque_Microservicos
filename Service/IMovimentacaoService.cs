using Domain;
using System.Threading.Tasks;

namespace Service
{
    public interface IMovimentacaoService
    {
        void ValidarDataPerecivel(Produto produto);
        Task RealizarEntradaAsync(MovEstoque mov);
        Task RealizarSaidaAsync(MovEstoque mov);
    }
}
