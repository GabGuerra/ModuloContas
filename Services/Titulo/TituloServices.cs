using ModuloContas.Models.Resultado;
using ModuloContas.Models.Titulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloContas.Services.Titulo
{
    public abstract class TituloServices
    {
        public abstract ResultadoVD InserirTitulo(TituloVD titulo);
    }
}
