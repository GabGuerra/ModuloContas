using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloContas.Models.Resultado
{
    public class ResultadoVD
    {
        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }

        public ResultadoVD()
        {

        }

        public ResultadoVD(bool sucesso)
        {
            Sucesso = sucesso;
        }

        public ResultadoVD(string mensagem, bool sucesso)
        {
            Mensagem = mensagem;
            Sucesso = sucesso;
        }
    }
}
