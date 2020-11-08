using ModuloContas.Models.FormaPagamento;

namespace ModuloContas.Models.Pagamento
{
    public class PagamentoVD
    {
        public int NumParcelas { get; set; }
        public FormaPagamentoVD FormaPagamento { get; set; }
        public PagamentoVD()
        {            
        }
    }
}
