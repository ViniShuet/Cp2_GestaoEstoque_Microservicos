using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public interface IRelatorioService
    {
       
        Task<decimal> CalcularValorTotalAsync();

        
        Task<IEnumerable<Produto>> VencendoEm7DiasAsync();
        Task<IEnumerable<Produto>> AbaixoDoMinimoAsync();
    }
}
