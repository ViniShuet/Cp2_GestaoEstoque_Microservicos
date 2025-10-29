using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal class MovEstoque
    {
        public Boolean Tipo { get; set; }
        public int Qtd { get; set; }
        public DateTime DataMov{ get; set; } 
        public int Lote{ get; set; } //Produtos pereciveis
        public string DataValidade { get; set; } //para pereciveis
    }
}
