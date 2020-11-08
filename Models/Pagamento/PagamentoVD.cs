using ModuloContas.Models.TipoPagamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloContas.Models.Pagamento
{
    public class PagamentoVD
    {
        public int NumParcelas { get; set; }
        public TipoPagamentoVD TipoPagamento { get; set; }
        public PagamentoVD()
        {

        }
    }
}
