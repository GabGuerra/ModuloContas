using ModuloContas.Models.Beneficiario;
using ModuloContas.Models.MovimentacaoTitulo;
using ModuloContas.Models.Pagamento;
using System;
using System.Collections.Generic;

namespace ModuloContas.Models.Titulo
{
    public class TituloVD
    {
        public long? CodTitulo { get; set; }
        public double VlrAberto { get; set; }
        public double VlrOriginal { get; set; }
        public DateTime DatVencimento { get; set; }
        public TituloVD TituloPai { get; set; }
        public PagamentoVD InfoPagamento { get; set; }
        public List<MovimentacaoTituloVD> ListaMovimentacoes { get; set; }
        public BeneficiarioVD Beneficiario { get; set; }
      
        public TituloVD()
        {
            TituloPai = new TituloVD();
            InfoPagamento = new PagamentoVD();
            Beneficiario = new BeneficiarioVD();
            ListaMovimentacoes = new List<MovimentacaoTituloVD>();
        }
    }
}
