using ModuloContas.Models.Beneficiario;
using ModuloContas.Models.MovimentacaoTitulo;
using ModuloContas.Models.Pagamento;
using ModuloContas.Models.Sacado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloContas.Models.Titulo
{
    public class ContaReceberVD : TituloVD
    {
        public bool isParcelado { get { return InfoPagamento.NumParcelas > 1; } }
        public ContaReceberVD()
        {
            TituloPai = new TituloVD();
            InfoPagamento = new PagamentoVD();
            Sacado = new SacadoVD();
            ListaMovimentacoes = new List<MovimentacaoTituloVD>();
        }
        public ContaReceberVD
        (
               long? codTitulo,
               double vlrAberto,
               double vlrOriginal,
               DateTime datVencimento,
               TituloVD tituloPai,
               PagamentoVD infoPagamento,
               List<MovimentacaoTituloVD> listaMovimentacoes,
               SacadoVD sacado
        )
        {
            CodTitulo = codTitulo;
            VlrAberto = vlrAberto;
            VlrOriginal = vlrOriginal;
            DatVencimento = datVencimento;
            TituloPai = tituloPai;
            InfoPagamento = infoPagamento;
            ListaMovimentacoes = listaMovimentacoes;
            Sacado = sacado;
        }
    }
}
