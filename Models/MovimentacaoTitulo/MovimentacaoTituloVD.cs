using ModuloContas.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloContas.Models.MovimentacaoTitulo
{
    public class MovimentacaoTituloVD
    {
        public long CodMovimentacao { get; set; }
        public DateTime DatMovimentacao { get; set; }
        public double VlrMovimentacao { get; set; }
        public decimal VlrDesconto { get; set; }
        public decimal VlrJuros { get; set; }
        public decimal VlrMulta { get; set; }
        public TipoMovimentacao TipoMovimentacao { get; set; }

        public MovimentacaoTituloVD()
        {

        }
        public MovimentacaoTituloVD(double vlrMovimentacao, decimal vlrDesconto, decimal vlrJuros, decimal vlrMulta)
        {
            this.VlrMovimentacao = vlrMovimentacao;
            this.VlrDesconto = vlrDesconto;
            this.VlrJuros = vlrJuros;
            this.VlrMulta = vlrMulta;
        }
    }
}
