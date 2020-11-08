using ModuloContas.Models.Titulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloContas.Repository.ContaPagar
{
    public interface IContaPagarRepository
    {
        public void InserirContaPagar(ContaPagarVD contaPagar);
    }
}
