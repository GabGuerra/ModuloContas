using ModuloContas.Models.Beneficiario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloContas.Models.Titulo
{
    public class ContaPagarVD : TituloVD
    {
        public BeneficiarioVD Beneficiario { get; set; }
        public ContaPagarVD()
        {

        }
    }
}
