using ModuloContas.Models.Resultado;
using ModuloContas.Models.Titulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloContas.Services.ContaPagar
{
    public interface IContaPagarService
    {
        public ResultadoVD ProcessarContaPagar(ContaPagarVD contaPagar);
    }
}
