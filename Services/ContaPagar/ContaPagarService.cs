using ModuloContas.Models.Resultado;
using ModuloContas.Models.Titulo;
using ModuloContas.Repository.ContaPagar;
using ModuloContas.Services.Titulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloContas.Services.ContaPagar
{
    public class ContaPagarService : TituloServices, IContaPagarService
    {
        private readonly IContaPagarRepository _contaPagarRepository;
        public override ResultadoVD InserirTitulo(TituloVD contaPagar)
        {
            ResultadoVD resultado = new ResultadoVD();

            try
            {
                _contaPagarRepository.InserirContaPagar(contaPagar);
            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = $"Não foi possível inserir a conta. {Environment.NewLine} {ex.Message}";
            }

            return resultado;
        }

     
    }
}
