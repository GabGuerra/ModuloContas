using ModuloContas.Models.MovimentacaoTitulo;
using ModuloContas.Models.Resultado;
using ModuloContas.Models.Titulo;
using ModuloContas.Repository.ContaPagar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ModuloContas.Services.ContaPagar
{
    public class ContaPagarService : IContaPagarService, ITituloServices<ContaPagarVD>
    {
        private readonly IContaPagarRepository _contaPagarRepository;

        public ContaPagarService(IContaPagarRepository contaPagarRepository)
        {
            _contaPagarRepository = contaPagarRepository;
        }
        public ResultadoVD ProcessarContaPagar(ContaPagarVD contaPagar) 
        {
            ResultadoVD resultado = new ResultadoVD(true);
            InserirTitulo(contaPagar);            

            try
            {
                if (contaPagar.isParcelado) 
                {
                    ProcessarPagamentoParcelado(contaPagar);                    
                    _contaPagarRepository.InserirMovimentacaoSubstituicao(contaPagar.CodTitulo.Value);
                }                      
            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = $"Não foi possível inserir a conta. {Environment.NewLine} {ex.Message}";
            }

            return resultado;
        }
        public void InserirTitulo(ContaPagarVD contaPagar)
        {            
            try
            {
                contaPagar.CodTitulo = _contaPagarRepository.InserirContaPagar(contaPagar);                             
            }
            catch
            {
                throw;
            }            
        }

        public void ProcessarPagamentoParcelado(ContaPagarVD contaPai)
        {
            for (int i = 1; i <= contaPai.InfoPagamento.NumParcelas; i++)
            {
                var vlrParcela = contaPai.VlrOriginal / contaPai.InfoPagamento.NumParcelas;
                var contaPagar = new ContaPagarVD
                    (
                        null,
                        vlrParcela,
                        vlrParcela,
                        contaPai.DatVencimento.AddMonths(i),
                        contaPai,
                        contaPai.InfoPagamento,
                        new List<MovimentacaoTituloVD>(),
                        contaPai.Beneficiario
                    ) ;

                _contaPagarRepository.InserirContaPagar(contaPagar);
            }    
        }

    }
}
