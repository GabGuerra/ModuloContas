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
        public TipoMovimentacaoVD TipoMovimentacao { get; set; }

        public MovimentacaoTituloVD()
        {

        }
    }
}
