using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloContas.Models
{
    public class TipoMovimentacaoVD
    {
        public string DscTipoMovimentacao { get; set; }
        public int CodTipoMovimentacao { get; set; }
        public TipoMovimentacaoVD()
        {

        }
        public TipoMovimentacaoVD(string dscTipoMovimentacao, int codTipoMovimentacao)
        {
            DscTipoMovimentacao = dscTipoMovimentacao;
            CodTipoMovimentacao = codTipoMovimentacao;
        }
    }
}
