using ModuloContas.Models.Resultado;
using ModuloContas.Models.Titulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloContas.Services.Titulo
{
    public class TituloServices<T> where T : TituloVD
    {
        public ResultadoVD InserirTitulo(T titulo) 
        {

            return new ResultadoVD();
        }
    }
}
